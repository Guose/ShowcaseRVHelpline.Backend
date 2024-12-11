using Microsoft.Extensions.Configuration;

namespace Helpline.API.Controller.Config.JwtAuthenticationConfig
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
