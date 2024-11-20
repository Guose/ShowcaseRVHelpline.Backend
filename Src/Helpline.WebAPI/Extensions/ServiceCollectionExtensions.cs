using Helpline.Common.Interfaces;
using Helpline.Common.Logging;
using Helpline.DataAccess.Data;
using Helpline.DataAccess.Models.Helpers;
using Helpline.Domain.Data;
using Helpline.Domain.Services;
using Helpline.WebAPI.Controller.Configuration.JwtAuthenticationConfig;
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
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IRedisCacheService, RedisCacheService>();
        }

        public static IServiceCollection AddFeatureServices(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IDictionaryConvertable<,>), typeof(DictionaryHelper<,>))
                .AddScoped<BedTypeService>()
                .AddScoped<RvFeatureService>();
        }
    }

}
