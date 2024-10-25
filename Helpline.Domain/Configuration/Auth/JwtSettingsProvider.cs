using Microsoft.Extensions.Configuration;

namespace Helpline.Domain.Configuration.Auth
{
    public class JwtSettingsProvider
    {
        public JwtSettings LoadJwtSettings(IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.GetSection("JwtSettings").Bind(jwtSettings);

            return jwtSettings;
        }
    }
}
