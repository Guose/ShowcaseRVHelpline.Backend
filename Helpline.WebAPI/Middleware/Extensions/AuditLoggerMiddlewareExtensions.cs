using Helpline.WebAPI.Middleware.AuditLogger;

namespace Helpline.WebAPI.Middleware.Extensions
{
    public static class AuditLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuditLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuditLoggerMiddleware>();
        }
    }
}
