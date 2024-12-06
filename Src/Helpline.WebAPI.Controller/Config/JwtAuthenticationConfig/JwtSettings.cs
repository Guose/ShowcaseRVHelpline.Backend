using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Domain.ValueObjects;

namespace Helpline.WebAPI.Controller.Config.JwtAuthenticationConfig
{
    public class JwtSettings
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string SecurityKey { get; set; } = string.Empty;
        public int ExpiryMinutes { get; set; } = 1;
    }

    public class LoginUserDto
    {
        public required string UserNameDto { get; set; }
        public required string Password { get; set; }
        public double AuthInterval { get; set; } = 1;
        public bool IsRemembered { get; set; }

        /// <summary>
        /// Maps the response from the server
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<LoginUserDto> MapLoginUserDTO(ApplicationUser user)
        {
            var userNameValueObject = UserName.Create(user.UserName!);

            return await Task.Run(() => new LoginUserDto
            {
                UserNameDto = userNameValueObject.Value.Value,
                Password = user.Password!,
                IsRemembered = user.IsRemembered,
            });
        }

        /// <summary>
        /// Maps the request to the User model
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public static async Task<ApplicationUser> MapPlatformUserModel(LoginUserDto userDto)
        {
            Result<UserName> userNameResult = UserName.Create(userDto.UserNameDto!);
            return await Task.Run(() => new ApplicationUser
            {
                UserName = userDto.UserNameDto,
            });
        }
    }

    public class TokenRenewalRequest
    {
        public string Token { get; set; } = string.Empty;
        public double AuthInterval { get; set; }
    }
}
