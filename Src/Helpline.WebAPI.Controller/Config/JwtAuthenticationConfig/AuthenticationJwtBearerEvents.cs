using Helpline.Common.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;

namespace Helpline.WebAPI.Controller.Config.JwtAuthenticationConfig
{
    public class AuthenticationJwtBearerEvents : JwtBearerEvents
    {
        private readonly ILogging logger;

        public AuthenticationJwtBearerEvents(ILogger<AuthenticationJwtBearerEvents> logger)
        {
            this.logger = (ILogging?)logger!;
        }

        public override Task AuthenticationFailed(AuthenticationFailedContext context)
        {
            logger.LogError("Authentication Error", context.Exception);
            return base.AuthenticationFailed(context);
        }
    }
}
