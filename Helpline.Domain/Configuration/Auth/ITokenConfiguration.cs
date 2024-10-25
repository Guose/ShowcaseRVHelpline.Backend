using System.Security.Claims;

namespace Helpline.Domain.Configuration.Auth
{
    public interface ITokenConfiguration
    {
        bool GenerateToken(string username, string userId, double interval, out string authToken);

        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);

        JwtSettings GetJwtSettings();
    }
}
