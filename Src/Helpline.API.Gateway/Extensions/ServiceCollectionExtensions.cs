using Helpline.API.Controller.Config.JwtAuthenticationConfig;
using Helpline.Common.Interfaces;
using Helpline.Common.Logging;
using Helpline.DataAccess.Data.Repositories;
using Helpline.DataAccess.Handlers;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Helpers;
using Helpline.Domain.Services;

namespace Helpline.API.Gateway.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ILogging, Logging>()
                .AddScoped<ITokenConfiguration, TokenConfiguration>();
            //.AddScoped<IRedisCacheService, RedisCacheService>();
        }

        public static IServiceCollection AddFeatureServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<ConvertDomainEventsToOutboxMessageHandler>()
                .AddSingleton<UpdateAuditableEntitiesHandler>()
                .AddScoped(typeof(IDictionaryConvertable<,>), typeof(DictionaryHelper<,>))
                .AddScoped<BedTypeService>()
                .AddScoped<RvFeatureService>()
                .AddTransient<IApplicationUserRepository, ApplicationUserRepository>()
                .AddTransient<ITechnicianRepository, TechnicianRepository>()
                .AddTransient<IEmployeeRepository, EmployeeRepository>()
                .AddTransient<IAddressRepository, AddressRepository>();
        }
    }
}
