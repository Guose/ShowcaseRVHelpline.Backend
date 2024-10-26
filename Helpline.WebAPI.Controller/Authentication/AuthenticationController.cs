using Helpline.Common.Models;
using Helpline.Domain.Data.Interfaces;
using Helpline.WebAPI.Controller.Configuration.Authenticate;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.Authentication
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenConfiguration tokenConfiguration;
        private readonly IApplicationUserRepository applicationUserRepository;

        public AuthenticationController(ITokenConfiguration tokenConfiguration, IApplicationUserRepository applicationUserRepository)
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

            if (login.UserName != user.UserName && !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
            {                
                return Unauthorized();
            }
            var token = tokenConfiguration.GenerateToken(user.UserName!, user.Id, login.AuthInterval, out string authToken);

            if (token)
                return Ok(new { User = user, Token = authToken });
            else
                return BadRequest("Token could not be generated.");
        }
    }
}
