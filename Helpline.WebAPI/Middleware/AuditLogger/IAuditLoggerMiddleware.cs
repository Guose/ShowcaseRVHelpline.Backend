namespace Helpline.WebAPI.Middleware.AuditLogger
{
    public interface IAuditLoggerMiddleware
    {
        Task InvokeAsync(HttpContext context);
    }
}
