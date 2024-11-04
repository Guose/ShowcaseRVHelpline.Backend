using System.Fabric;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using Helpline.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Newtonsoft.Json.Serialization;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net.WebSockets;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Data.Repositories;
using Helpline.Common.Interfaces;
using Helpline.Common.Logging;
using Helpline.WebAPI.Controller.Configuration.Authenticate;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Helpline.WebAPI.Controller.Authentication;
using Helpline.WebAPI.Middleware.AuditLogger;
using System.Xml.XPath;
using Microsoft.Extensions.FileProviders;
using System.Xml;
using Helpline.Common.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using Helpline.Common.Authorization.Handlers;
using Helpline.Common.Types;
using Helpline.Common.Constants;
using Helpline.WebAPI.Controller.Validation;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using FluentValidation;
using Helpline.Common.Models;
using Microsoft.AspNetCore.Identity;
using Helpline.Domain.Data;
using Helpline.WebAPI.Services.Caching;

namespace Helpline.WebAPI
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance.
    /// </summary>
    internal sealed class WebAPI : StatelessService
    {
        private readonly string swaggerXMLFileName = "SomeFile.XML";
        public WebAPI(StatelessServiceContext context)
            : base(context)
        {
            // ManifestEmbeddedFileProvider = new ManifestEmbeddedFileProvider(typeof(WebAPI).Assembly);
        }

        private static ManifestEmbeddedFileProvider? ManifestEmbeddedFileProvider { get; set; }

        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext =>
                    new KestrelCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
                        ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting Kestrel on {url}");

                        var builder = WebApplication.CreateBuilder();

                        var configuration = new ConfigurationBuilder()
                            .SetBasePath(builder.Environment.ContentRootPath)
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables()
                            .Build();

                        builder.Services.AddSingleton(serviceContext);
                        builder.Services.AddHttpContextAccessor();

                        // Add services to the container.
                        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                        builder.Services.AddScoped<ILogging, Logging>();
                        builder.Services.AddScoped<ITokenConfiguration, TokenConfiguration>();
                        builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
                        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
                        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
                        builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();

                        int port = serviceContext.CodePackageActivationContext.GetEndpoint("ServiceEndpoint").Port;

                        // Configure Kestrel to use HTTPS
                        builder.WebHost.UseKestrel(opt =>
                        {
                            opt.ListenAnyIP(port, httpOpts =>
                            {
                                var certificate = GetCertificateFromStore(); // Ensure this is not null
                                if (certificate == null)
                                {
                                    throw new Exception("Certificate could not be loaded from the store.");
                                }

                                httpOpts.UseHttps(certificate);
                            });
                        });

                        // Use the Service Fabric integration
                        builder.WebHost
                            .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                            .UseContentRoot(Directory.GetCurrentDirectory())
                            .UseUrls(url);

                        builder.Services.AddDbContext<HelplineContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

                        builder.Services.AddStackExchangeRedisCache(options =>
                        {
                            options.Configuration = builder.Configuration.GetConnectionString("Redis");
                            options.InstanceName = "RVHelplineAPI_";
                        });

                        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<HelplineContext>()
                            .AddDefaultTokenProviders();

                        builder.Services.AddControllers(options =>
                        {
                            options.Filters.Add(typeof(ValidationActionFilter));

                            AddODataSupportMedia(options);
                        })
                        .AddNewtonsoftJson(settings =>
                        {
                            settings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                            settings.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        })
                        .AddOData(opt =>
                            opt.Select().Filter().OrderBy().Expand())
                        .AddJsonOptions(options =>
                        {
                            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                        }).PartManager.ApplicationParts.Add(new AssemblyPart(typeof(AuthenticationController).Assembly));

                        
                        builder.Services.AddValidatorsFromAssemblyContaining<ValidationActionFilter>();

                        builder.Services.AddCors(options =>
                        {
                            options.AddPolicy("CorsPolicy", corsBuilder =>
                            {
                                corsBuilder
                                .WithOrigins("http://localhost:3001")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials();
                            });
                        });

                        var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:SecurityKey"]!);

                        builder.Services.AddAuthentication(options =>
                        {
                            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        })
                        .AddJwtBearer(opt =>
                        {
                            opt.RequireHttpsMetadata = false;
                            opt.SaveToken = true;
                            opt.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = new SymmetricSecurityKey(key),
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidIssuer = builder.Configuration["JwtSettings:Issuer"]!,
                                ValidAudience = builder.Configuration["JwtSettings:Audience"]!
                            };
                        });

                        builder.Services.AddSingleton<IAuthorizationHandler, AllowHelplineAccessHandler>();

                        builder.Services.AddAuthorization(options =>
                        {
                            var fullAccessAdminPolicyRequirement = new HelplineAccessRequirment(RoleType.Admin, PermissionType.Admin);

                            var authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                            authorizationPolicyBuilder.Requirements.Add(fullAccessAdminPolicyRequirement);
                            options.AddPolicy(HelplineConstants.AdministratorPolicy, authorizationPolicyBuilder.Build());

                            var employeeAdminPolicyRequirement = new HelplineAccessRequirment(RoleType.Employee, PermissionType.Admin);

                            authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                            authorizationPolicyBuilder.Requirements.Add(employeeAdminPolicyRequirement);
                            options.AddPolicy(HelplineConstants.EmployeeAdminPolicy, authorizationPolicyBuilder.Build());

                            var employeeContractorPolicyRequirement = new HelplineAccessRequirment(RoleType.Employee, PermissionType.Contractor);

                            authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                            authorizationPolicyBuilder.Requirements.Add(employeeContractorPolicyRequirement);
                            options.AddPolicy(HelplineConstants.EmployeeContractorPolicy, authorizationPolicyBuilder.Build());

                            var employeeLimitedPolicyRequirement = new HelplineAccessRequirment(RoleType.Employee, PermissionType.Limited);

                            authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                            authorizationPolicyBuilder.Requirements.Add(employeeLimitedPolicyRequirement);
                            options.AddPolicy(HelplineConstants.EmployeeLimitedPolicy, authorizationPolicyBuilder.Build());

                            var customerLimitedPolicyRequirement = new HelplineAccessRequirment(RoleType.Customer, PermissionType.Limited);

                            authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                            authorizationPolicyBuilder.Requirements.Add(customerLimitedPolicyRequirement);
                            options.AddPolicy(HelplineConstants.CustomerLimitedPolicy, authorizationPolicyBuilder.Build());

                            var customerGuestPolicyRequirement = new HelplineAccessRequirment(RoleType.Customer, PermissionType.Guest);

                            authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                            authorizationPolicyBuilder.Requirements.Add(customerGuestPolicyRequirement);
                            options.AddPolicy(HelplineConstants.CustomerGuestPolicy, authorizationPolicyBuilder.Build());

                            var rvRenterGuestPolicyRequirment = new HelplineAccessRequirment(RoleType.RVRenter, PermissionType.Guest);

                            authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                            authorizationPolicyBuilder.Requirements.Add(rvRenterGuestPolicyRequirment);
                            options.AddPolicy(HelplineConstants.RVRenterGuestPolicy, authorizationPolicyBuilder.Build());

                            var technicianLimitedPolicyRequirement = new HelplineAccessRequirment(RoleType.Technician, PermissionType.Limited);

                            authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                            authorizationPolicyBuilder.Requirements.Add(technicianLimitedPolicyRequirement);
                            options.AddPolicy(HelplineConstants.TechnicianLimitedPolicy, authorizationPolicyBuilder.Build());

                            var dealershipLimitedPolicyRequirement = new HelplineAccessRequirment(RoleType.Dealership, PermissionType.Limited);

                            authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                            authorizationPolicyBuilder.Requirements.Add(dealershipLimitedPolicyRequirement);
                            options.AddPolicy(HelplineConstants.DealershipLimitedPolicy, authorizationPolicyBuilder.Build());

                            var contractorPolicyRequirement = new HelplineAccessRequirment(RoleType.Contractor, PermissionType.Limited);

                            authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                            authorizationPolicyBuilder.Requirements.Add(contractorPolicyRequirement);
                            options.AddPolicy(HelplineConstants.ContractorPolicy, authorizationPolicyBuilder.Build());
                        });

                        builder.Services.AddEndpointsApiExplorer();

                        builder.Services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT Auth API", Version = "v1" });
                            // c.IncludeXmlComments(SwaggerXMLCommentFileFactory);

                            var securitySchema = new OpenApiSecurityScheme
                            {
                                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                                Name = "Authorization",
                                In = ParameterLocation.Header,
                                Type = SecuritySchemeType.Http,
                                Scheme = "bearer",
                                BearerFormat = "JWT",
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            };

                            c.AddSecurityDefinition("Bearer", securitySchema);

                            var securityRequirement = new OpenApiSecurityRequirement
                            {
                                { securitySchema, new[] { "Bearer" } }
                            };

                            c.AddSecurityRequirement(securityRequirement);
                        });

                        var app = builder.Build();

                        if (app.Environment.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                            app.UseSwagger();
                            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWT Auth API v1"));
                        }

                        app.UseWebSockets();

                        app.UseCors("CorsPolicy");

                        app.Use(async (context, next) =>
                        {
                            if (context.WebSockets.IsWebSocketRequest)
                            {
                                var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                                await HandleWebSocket(context, webSocket);
                            }
                            else
                            {
                                await next();
                            }
                        });

                        //app.UseMiddleware<IAuditLoggerMiddleware>();

                        app.UseHttpsRedirection();

                        app.UseAuthentication();

                        app.UseAuthorization();

                        app.MapControllers();

                        return app;

                    }))
            };
        }

        private static void AddODataSupportMedia(MvcOptions options)
        {
            IEnumerable<ODataOutputFormatter> outputFormatters = options.OutputFormatters
                                                                    .OfType<ODataOutputFormatter>()
                                                                    .Where(formatter => formatter.SupportedMediaTypes.Count == 0);

            foreach (var outputFormatter in outputFormatters)
            {
                outputFormatter.SupportedMediaTypes.Add(new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("application/odata"));
            }
        }

        private XPathDocument SwaggerXMLCommentFileFactory()
        {
            using Stream s = ManifestEmbeddedFileProvider!.GetFileInfo(swaggerXMLFileName).CreateReadStream();
            return new XPathDocument(XmlReader.Create(s));
        }

        /// <summary>
        /// Finds the ASP .NET Core HTTPS development certificate in development environment. Update this method to use the appropriate certificate for production environment.
        /// </summary>
        /// <returns>Returns the ASP .NET Core HTTPS development certificate</returns>
        private static X509Certificate2 GetCertificateFromStore(string? subjectName = null)
        {
            string thumbprint = "b24ca9a25ed7b0c79174f9b6a6823adffe159b55";
            using var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var certCollection = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, validOnly: false);

            if (certCollection.Count == 0)
            {
                throw new Exception($"Certificate with thumbprint {thumbprint} not found in the store.");
            }

            // Optional additional check by subject name
            if (!string.IsNullOrEmpty(subjectName))
            {
                certCollection = certCollection.Find(X509FindType.FindBySubjectName, subjectName, validOnly: false);
                if (certCollection.Count == 0)
                {
                    throw new Exception($"Certificate with subject name {subjectName} and thumbprint {thumbprint} not found.");
                }
            }

            return certCollection[0];
        }


        private static async Task HandleWebSocket(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                var criteria = Encoding.UTF8.GetString(buffer, 0, result.Count);
                var filteredData = ApplyCriteria(criteria);

                var serverMsg = Encoding.UTF8.GetBytes(filteredData);
                await webSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        private static string ApplyCriteria(string criteria)
        {
            return $"Needs to be implemented on how we're going to pass in criteria: {criteria}";
        }
    }
}
