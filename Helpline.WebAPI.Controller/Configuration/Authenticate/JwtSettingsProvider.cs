using Microsoft.Extensions.Configuration;

namespace Helpline.WebAPI.Controller.Configuration.Authenticate
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
