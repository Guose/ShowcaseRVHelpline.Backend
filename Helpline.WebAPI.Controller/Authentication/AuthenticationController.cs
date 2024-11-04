using AutoMapper;
using Helpline.Common.Models;
using Helpline.Domain.Data;
using Helpline.Domain.Data.Interfaces;
using Helpline.UserServices.DTOs.Responses;
using Helpline.WebAPI.Controller.Configuration;
using Helpline.WebAPI.Controller.Configuration.Authenticate;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.Authentication
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly ITokenConfiguration tokenConfiguration;
        public AuthenticationController(IUnitOfWork unitOfWork, IMapper mapper, ITokenConfiguration tokenConfiguration) : base(unitOfWork, mapper)
        {
            this.tokenConfiguration = tokenConfiguration;
        }

        [HttpPost("AuthenticateUser")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto login)
        {
            ApplicationUser? user = await unitOfWork.UserRepo.ValidateUsernameAsync(login.UserName);

            if (user == null)
            {
                return NotFound("Username does not exist");
            }

            if (login.UserName != user.UserName && !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
            {                
                return Unauthorized();
            }
            var token = tokenConfiguration.GenerateToken(user.UserName!, user.Id, login.AuthInterval, out string authToken);

            var result = mapper.Map<UserResponse>(user);

            if (token)
                return Ok(new { User = result, Token = authToken });
            else
                return BadRequest("Token could not be generated.");
        }
    }
}
