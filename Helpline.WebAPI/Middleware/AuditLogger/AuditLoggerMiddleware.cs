using System.Diagnostics;
using System.Net;

namespace Helpline.WebAPI.Middleware.AuditLogger
{
    public class AuditLoggerMiddleware : IAuditLoggerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<AuditLoggerMiddleware> logger;

        public AuditLoggerMiddleware(RequestDelegate next, ILogger<AuditLoggerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            HttpStatusCode resultCode = HttpStatusCode.OK;
            try
            {
                var request = context.Request;
                var user = context.User?.Identity?.Name ?? "Anonymous";
                var ipAddress = context.Connection.RemoteIpAddress?.ToString() ?? "unknown IP";

                // Log the incoming request
                logger.LogInformation("Incoming request: {Method} {Path} from {IPAddress} by {UserName}",
                    request.Method, request.Path, ipAddress, user);

                // Call the next middleware in the pipeline
                await next(context).ConfigureAwait(false);

                // Record the result code
                resultCode = (HttpStatusCode)context.Response.StatusCode;

                // Log the response status code
                var response = context.Response;
                logger.LogInformation("Response: {StatusCode} for {Method} {Path} from {IPAddress} by {UserName}",
                    response.StatusCode, request.Method, request.Path, ipAddress, user);
            }
            catch (Exception ex)
            {
                sw.Stop();
                throw new Exception(ex.Message);
            }
        }
    }
}
