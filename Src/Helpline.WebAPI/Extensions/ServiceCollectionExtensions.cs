using Helpline.Common.Interfaces;
using Helpline.Common.Logging;
using Helpline.DataAccess.Handlers;
using Helpline.Domain.Models.Helpers;
using Helpline.Domain.Services;
using Helpline.WebAPI.Controller.Config.JwtAuthenticationConfig;
using Helpline.WebAPI.Services.Caching;

namespace Helpline.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ILogging, Logging>()
                .AddScoped<ITokenConfiguration, TokenConfiguration>()
                .AddScoped<IRedisCacheService, RedisCacheService>();
        }

        public static IServiceCollection AddFeatureServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<ConvertDomainEventsToOutboxMessageHandler>()
                .AddSingleton<UpdateAuditableEntitiesHandler>()
                .AddScoped(typeof(IDictionaryConvertable<,>), typeof(DictionaryHelper<,>))
                .AddScoped<BedTypeService>()
                .AddScoped<RvFeatureService>();
        }
    }

}
