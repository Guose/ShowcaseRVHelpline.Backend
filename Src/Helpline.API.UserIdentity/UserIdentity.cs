using Helpline.DataAccess.Context;
using Helpline.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using System.Fabric;
using System.Security.Cryptography.X509Certificates;

namespace Helpline.API.UserIdentity
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance.
    /// </summary>
    internal sealed class UserIdentity : StatefulService
    {
        public UserIdentity(StatefulServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new ServiceReplicaListener[]
            {
                new ServiceReplicaListener(serviceContext =>
                    new KestrelCommunicationListener(serviceContext, (url, listener) =>
                    {
                        ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting Kestrel on {url}");

                        var builder = WebApplication.CreateBuilder();

                        builder.Services
                                    .AddSingleton<StatefulServiceContext>(serviceContext)
                                    .AddSingleton<IReliableStateManager>(this.StateManager);

                        int port = serviceContext.CodePackageActivationContext.GetEndpoint("ServiceEndpoint").Port;

                        builder.WebHost
                                    .UseKestrel(opt =>
                                    {
                                        opt.ListenAnyIP(port, httpOpts =>
                                        {
                                            var certificate = GetCertificateFromStore() ??
                                                throw new Exception("Certificate could not be loaded from the store.");

                                            httpOpts.UseHttps(certificate);
                                        });
                                    })
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.UseUniqueServiceUrl)
                                    .UseUrls(url);

                        builder.Services.AddDbContext<HelplineContext>(options =>
                            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerUserConnection")));

                        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<HelplineContext>()
                            .AddDefaultTokenProviders();

                        builder.Services.AddControllersWithViews();
                        var app = builder.Build();
                        if (!app.Environment.IsDevelopment())
                        {
                            app.UseExceptionHandler("/Home/Error");
                        }
                        app.UseStaticFiles();
                        app.UseRouting();

                        app.UseAuthentication();
                        app.UseAuthorization();

                        app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

                        return app;

                    }))
            };
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
    }
}
