using Helpline.Common.Models;
using Helpline.Domain.Configuration.Auth;
using Helpline.Domain.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenConfiguration tokenConfiguration;
        private readonly IApplicationUserRepository applicationUserRepository;

        public AuthController(ITokenConfiguration tokenConfiguration, IApplicationUserRepository applicationUserRepository)
        {
            this.tokenConfiguration = tokenConfiguration;
            this.applicationUserRepository = applicationUserRepository;
        }

        [HttpPost("AuthenticateUser")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto login)
        {
            ApplicationUser? user = await applicationUserRepository.ValidateUsernameAsync(login.UserName);

            if (user == null)
            {
                return NotFound("Username does not exist");
            }

            if (login.UserName == user.UserName && BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
            {
                return tokenConfiguration.GenerateToken(user.UserName!, user.Id, login.AuthInterval, out string authToken)
                    ? Ok(new { User = user, Token = authToken })
                    : BadRequest("Token could not be generated.");
            }

            return Unauthorized();

            //if (string.IsNullOrEmpty(userId))
            //{
            //    return BadRequest("User Id is required");
            //}

            //// Create claims based on the user ID
            //var claims = new[]
            //{
            //    new Claim(JwtRegisteredClaimNames.Sub, userId),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //};

            //// Generate the signing key from the secret key
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //// Create the JWT token
            //var token = new JwtSecurityToken(
            //    issuer: jwtSettings.Issuer,
            //    audience:jwtSettings.Audience,
            //    claims: claims,
            //    expires: DateTime.Now.AddMinutes(jwtSettings.ExpiryMinutes),
            //    signingCredentials: creds
            //);

            //// Return the generated token as a string
            //return Ok(new
            //{
            //    token = new JwtSecurityTokenHandler().WriteToken(token)
            //});
        }
    }
}
