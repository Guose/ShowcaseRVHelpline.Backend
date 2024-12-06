using AutoMapper;
using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Data;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.ValueObjects;
using Helpline.WebAPI.Controller.Config.JwtAuthenticationConfig;
using Helpline.WebAPI.Controller.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.v1.AccessControl
{
    [ApiController]
    [Route("api/[controller]")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class AuthenticationController : BaseController
    {
        private readonly ITokenConfiguration tokenConfiguration;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public AuthenticationController(
            IMediator sender,
            ITokenConfiguration tokenConfiguration,
            IMapper mapper,
            IUnitOfWork unitOfWork) : base(sender)
        {
            this.tokenConfiguration = tokenConfiguration;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("AuthenticateUser")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto login)
        {
            ApplicationUser? user = await unitOfWork.UserRepo.GetUserByUsernameAsync(UserName.Create(login.UserNameDto).Value);

            if (user == null)
            {
                return NotFound("Username does not exist");
            }

            if (login.UserNameDto != user.UserName && !BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash))
            {
                return Unauthorized();
            }
            var token = tokenConfiguration.GenerateToken(user.UserName!, user.Id, login.AuthInterval, out string authToken);

            var result = mapper.Map<UserResponse>(user);

            if (token && !string.IsNullOrEmpty(authToken))
                return Ok(new { User = result, Token = authToken });
            else
                return BadRequest("Token could not be generated.");
        }
    }
}
