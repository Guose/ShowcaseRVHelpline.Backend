using FluentValidation;
using Helpline.Core.BackgroundJobs;
using Helpline.Core.Idempotence;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Data.CacheRepositories;
using Helpline.DataAccess.Data.Repositories;
using Helpline.DataAccess.Handlers;
using Helpline.Domain.Data;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;
using Helpline.Services.Abstractions.Validation;
using Helpline.WebAPI.Controller.Config.Filters;
using Helpline.WebAPI.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Quartz;
using Quartz.Simpl;
using Scrutor;
using System.Fabric;
using System.Net.WebSockets;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Formatting = Newtonsoft.Json.Formatting;

namespace Helpline.WebAPI
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance.
    /// </summary>
    internal sealed class WebAPI : StatelessService
    {
        private readonly string swaggerXMLFileName = "SomeFile.XML";

        private readonly List<Assembly> assemblies =
        [
            Helpline.Services.Subscriptions.AssemblyReference.Assembly,
            Helpline.Services.Users.AssemblyReference.Assembly,
        ];

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

                        builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
                        builder.Services.Decorate<IApplicationUserRepository, CachedUserRepository>();

                        builder.Services.Scan(
                            selector => selector
                                .FromAssemblies(
                                    Core.AssemblyReference.Assembly,
                                    DataAccess.AssemblyReference.Assembly)
                                .AddClasses(classes => classes.AssignableTo<IUnitOfWork>())
                                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                                .AsImplementedInterfaces()
                                .WithScopedLifetime());

                        builder.Services.AddMemoryCache();

                        var webApiControllerAssembly = typeof(Controller.AssemblyReference).Assembly;

                        builder.Services.AddHttpContextAccessor();
                        int port = serviceContext.CodePackageActivationContext.GetEndpoint("ServiceEndpoint").Port;

                        // Configure Kestrel to use HTTPS
                        builder.WebHost.UseKestrel(opt =>
                        {
                            opt.ListenAnyIP(port, httpOpts =>
                            {
                                var certificate = GetCertificateFromStore() ??
                                    throw new Exception("Certificate could not be loaded from the store.");

                                httpOpts.UseHttps(certificate);
                            });
                        });                        

                        // Add Automapper to DI configuration
                        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                        // Injecting the MediatR into DI
                        builder.Services.AddMediatR(opt =>
                        {
                            opt.RegisterServicesFromAssemblies([.. assemblies]);
                        });

                        // Add Quartz
                        builder.Services.AddQuartz(config =>
                        {
                            config.UseJobFactory<MicrosoftDependencyInjectionJobFactory>();

                            var jobKey = new JobKey(nameof(ProcessOutboxMessageJob));

                            config
                            .AddJob<ProcessOutboxMessageJob>(jobKey)
                            .AddTrigger(
                                trigger =>
                                    trigger.ForJob(jobKey)
                                        .WithSimpleSchedule(
                                            schedule =>
                                                schedule.WithIntervalInSeconds(100)
                                                    .RepeatForever()));
                        });

                        builder.Services.AddQuartzHostedService();

                        // Add Pipeline Validation and Notification Handler
                        builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

                        builder.Services.AddScoped(typeof(INotificationHandler<>), typeof(IdempotentDomainEventHandler<>));

                        builder.Services.AddValidatorsFromAssemblies(assemblies, includeInternalTypes: true);

                        // Add services to the container using extension method.
                        builder.Services.AddCoreServices();
                        builder.Services.AddFeatureServices();

                        // Add DBContext
                        builder.Services.AddDbContext<HelplineContext>((sp, options) =>
                        {
                            var interceptorHandler = sp.GetService<ConvertDomainEventsToOutboxMessageHandler>();
                            var env = sp.GetRequiredService<IHostEnvironment>();

                            options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"))
                                .AddInterceptors(interceptorHandler!)
                                    .UseRootApplicationServiceProvider();

                            if (env.IsDevelopment())
                            {
                                options.EnableSensitiveDataLogging();
                            }
                        });

                        // Add IdentityUser to User and DbContext
                        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<HelplineContext>()
                            .AddDefaultTokenProviders()
                            .AddApiEndpoints();

                        builder.Services.AddStackExchangeRedisCache(options =>
                        {
                            options.Configuration = builder.Configuration.GetConnectionString("Redis");
                            options.InstanceName = "RVHelplineAPI_";
                        });

                        // Add Rate Limiting with RateLimiter

                        // Add Controllers
                        builder.Services.AddControllers(options =>
                        {
                            options.Filters.Add(typeof(ValidationActionFilter));

                            AddODataSupportMedia(options);
                        })
                        .AddNewtonsoftJson(settings =>
                        {
                            settings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                            settings.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                            settings.SerializerSettings.DateFormatString = "yyyy-MM-dd";
                            settings.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                            settings.SerializerSettings.Converters.Add(new StringEnumConverter());
                            settings.SerializerSettings.Formatting = Formatting.Indented;
                        })
                        .AddOData(opt => opt.Select().Filter().OrderBy().Expand())
                        .AddApplicationPart(Controller.AssemblyReference.Assembly);

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

                        //// Add Authentication
                        //var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:SecurityKey"]!);

                        //builder.Services.AddAuthentication(options =>
                        //{
                        //    options.DefaultAuthenticateScheme = BearerTokenDefaults.AuthenticationScheme;
                        //    options.DefaultChallengeScheme = BearerTokenDefaults.AuthenticationScheme;
                        //})
                        //.AddCookie(IdentityConstants.ApplicationScheme)
                        //.AddBearerToken(IdentityConstants.BearerScheme);

                        //builder.Services.AddSingleton<IAuthorizationHandler, AllowHelplineAccessHandler>();

                        //// Add Authorization
                        //builder.Services.AddAuthorization(options =>
                        //{
                        //    var fullAccessAdminPolicyRequirement = new HelplineAccessRequirment(RoleType.Admin, PermissionType.Admin);

                        //    var authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                        //    authorizationPolicyBuilder.Requirements.Add(fullAccessAdminPolicyRequirement);
                        //    options.AddPolicy(HelplinePolicies.AdministratorPolicy, authorizationPolicyBuilder.Build());

                        //    var employeeAdminPolicyRequirement = new HelplineAccessRequirment(RoleType.Employee, PermissionType.Admin);

                        //    authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                        //    authorizationPolicyBuilder.Requirements.Add(employeeAdminPolicyRequirement);
                        //    options.AddPolicy(HelplinePolicies.EmployeeAdminPolicy, authorizationPolicyBuilder.Build());

                        //    var employeeContractorPolicyRequirement = new HelplineAccessRequirment(RoleType.Employee, PermissionType.Contractor);

                        //    authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                        //    authorizationPolicyBuilder.Requirements.Add(employeeContractorPolicyRequirement);
                        //    options.AddPolicy(HelplinePolicies.EmployeeContractorPolicy, authorizationPolicyBuilder.Build());

                        //    var employeeLimitedPolicyRequirement = new HelplineAccessRequirment(RoleType.Employee, PermissionType.Limited);

                        //    authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                        //    authorizationPolicyBuilder.Requirements.Add(employeeLimitedPolicyRequirement);
                        //    options.AddPolicy(HelplinePolicies.EmployeeLimitedPolicy, authorizationPolicyBuilder.Build());

                        //    var customerLimitedPolicyRequirement = new HelplineAccessRequirment(RoleType.Customer, PermissionType.Limited);

                        //    authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                        //    authorizationPolicyBuilder.Requirements.Add(customerLimitedPolicyRequirement);
                        //    options.AddPolicy(HelplinePolicies.CustomerLimitedPolicy, authorizationPolicyBuilder.Build());

                        //    var customerGuestPolicyRequirement = new HelplineAccessRequirment(RoleType.Customer, PermissionType.Guest);

                        //    authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                        //    authorizationPolicyBuilder.Requirements.Add(customerGuestPolicyRequirement);
                        //    options.AddPolicy(HelplinePolicies.CustomerGuestPolicy, authorizationPolicyBuilder.Build());

                        //    var rvRenterGuestPolicyRequirment = new HelplineAccessRequirment(RoleType.RVRenter, PermissionType.Guest);

                        //    authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                        //    authorizationPolicyBuilder.Requirements.Add(rvRenterGuestPolicyRequirment);
                        //    options.AddPolicy(HelplinePolicies.RVRenterGuestPolicy, authorizationPolicyBuilder.Build());

                        //    var technicianLimitedPolicyRequirement = new HelplineAccessRequirment(RoleType.Technician, PermissionType.Limited);

                        //    authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                        //    authorizationPolicyBuilder.Requirements.Add(technicianLimitedPolicyRequirement);
                        //    options.AddPolicy(HelplinePolicies.TechnicianLimitedPolicy, authorizationPolicyBuilder.Build());

                        //    var dealershipLimitedPolicyRequirement = new HelplineAccessRequirment(RoleType.Dealership, PermissionType.Limited);

                        //    authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                        //    authorizationPolicyBuilder.Requirements.Add(dealershipLimitedPolicyRequirement);
                        //    options.AddPolicy(HelplinePolicies.DealershipLimitedPolicy, authorizationPolicyBuilder.Build());

                        //    var contractorPolicyRequirement = new HelplineAccessRequirment(RoleType.Contractor, PermissionType.Limited);

                        //    authorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                        //    authorizationPolicyBuilder.Requirements.Add(contractorPolicyRequirement);
                        //    options.AddPolicy(HelplinePolicies.ContractorPolicy, authorizationPolicyBuilder.Build());
                        //});

                        builder.Services.AddEndpointsApiExplorer();

                        builder.Services.AddSwaggerGen(c =>
                        {
                            c.SchemaFilter<EnumSchemaFilter>();
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
                                {
                                    securitySchema, new[]
                                    {
                                        "Bearer"
                                    }
                                }
                            };

                            c.AddSecurityRequirement(securityRequirement);
                        });

                        // Use the Service Fabric integration
                        builder.WebHost
                            .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                            .UseContentRoot(Directory.GetCurrentDirectory())
                            .UseUrls(url);

                        var app = builder.Build();

                        // Maybe inject UseEndpoints here, not sure, but do some digging on the advantages of using.

                        if (app.Environment.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                            app.UseSwagger();
                            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWT Auth API v1"));
                        }
                        else
                        {
                            app.UseExceptionHandler("/Home/Error");
                            app.UseHsts();
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

                        app.UseStaticFiles();

                        app.UseAuthentication();

                        app.UseAuthorization();

                        app.MapIdentityApi<ApplicationUser>();

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
        /// Finds the ASP .NET Core HTTPS development certificate in development environment. UpdateUserInfo this method to use the appropriate certificate for production environment.
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
