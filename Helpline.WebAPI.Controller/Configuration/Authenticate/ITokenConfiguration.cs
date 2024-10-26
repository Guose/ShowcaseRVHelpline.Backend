using System.Security.Claims;

namespace Helpline.WebAPI.Controller.Configuration.Authenticate
{
    public interface ITokenConfiguration
    {
        bool GenerateToken(string username, string userId, double interval, out string authToken);

        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);

        JwtSettings GetJwtSettings();
    }
}
