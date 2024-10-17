using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Serilog.Context;

namespace Helpline.WebAPI.AuditLogger
{
    public class AuditMiddleware
    {
        private readonly RequestDelegate next;
        private readonly HelplineContext dbContext;
        private readonly ILogger<AuditMiddleware> logger;

        public AuditMiddleware(RequestDelegate next, HelplineContext dbContext, ILogger<AuditMiddleware> logger)
        {
            this.next = next;
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            var user = context.User?.Identity?.Name ?? "Anonymous";
            var ipAddress = context.Connection.RemoteIpAddress?.ToString() ?? "unknown IP";

            using (LogContext.PushProperty("UserName", user))
            using (LogContext.PushProperty("IPAddress", ipAddress))
            {
                AuditLog auditLog = new AuditLog
                {
                    CreatedOn = DateTime.UtcNow,
                    UserName = user,
                    IPAddress = ipAddress,
                    Method = request.Method,
                    Path = request.Path,
                    StatusMessage = "Incoming request"
                };

                dbContext.AuditLogs.Add(auditLog);
                await dbContext.SaveChangesAsync();

                // Log the incoming request
                logger.LogInformation("Request: {Method} {Path} from {IPAddress} by {UserName}",
                    request.Method,
                    request.Path,
                    ipAddress,
                    user);

                // Proceed to the next middleware in the pipeline
                await next(context);

                // Log the response status code after the request is processed
                var response = context.Response;
                logger.LogInformation("Response: {StatusCode} for {Method} {Path} from {IPAddress} by {UserName}",
                    response.StatusCode,
                    request.Method,
                    request.Path,
                    ipAddress,
                    user);

                auditLog.StatusCode = context.Response.StatusCode;
                auditLog.StatusMessage = "Response sent";
                dbContext.AuditLogs.Update(auditLog);
                await dbContext.SaveChangesAsync();
            }            
        }
    }
}
