using AutoMapper;
using Helpline.Common.Models;
using Helpline.Domain.Data;
using Helpline.UserServices.Aggregator;
using Helpline.UserServices.Commands;
using Helpline.UserServices.DTOs.Requests;
using Helpline.UserServices.Queries;
using Helpline.WebAPI.Controller.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.v1.ApplicationUsers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserServicesController : BaseController
    {
        private readonly IMediator mediator;
        public UserServicesController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper)
        {
            this.mediator = mediator;
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("User/{id}")]
        public async Task<IActionResult> GetCustomerByUserId(string id)
        {
            var query = new GetUserQuery(id);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("User")]
        public async Task<IActionResult> CreateUserRequest([FromBody] UserRequest user)
        {
            if (user == null)
                return BadRequest("User data required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new UserCreateCommandRequest(user);
            var result = await mediator.Send(command);

            return CreatedAtAction(nameof(CreateUserRequest), new { userId = result.Id }, result);
        }

        [HttpPut("User/{userId}")]
        public async Task<IActionResult> UpdateUserRequest(string userId, [FromBody] UserRequest user)
        {
            if (user == null)
                return BadRequest("User data required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new UserUpdateCommandRequest(user, userId);
            return await mediator.Send(command) ? NoContent() : BadRequest();
        }

        [HttpDelete("User/{id}")]
        public async Task<IActionResult> DeleteUserWithAssociatedEntity(string id)
        {
            var command = new UserDeleteCommandRequest(id);
            return await mediator.Send(command) ? Ok("User successfully deleted.") : BadRequest();
        }
    }
}
