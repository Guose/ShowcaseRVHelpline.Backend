namespace Helpline.API.Gateway.Middleware.AuditLogger
{
    public interface IAuditLoggerMiddleware
    {
        Task InvokeAsync(HttpContext context);
    }
}
