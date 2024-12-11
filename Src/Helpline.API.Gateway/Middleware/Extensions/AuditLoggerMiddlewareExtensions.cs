using Helpline.API.Gateway.Middleware.AuditLogger;

namespace Helpline.API.Gateway.Middleware.Extensions
{
    public static class AuditLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuditLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuditLoggerMiddleware>();
        }
    }
}
