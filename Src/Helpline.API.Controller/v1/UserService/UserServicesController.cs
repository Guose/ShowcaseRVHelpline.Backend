using Helpline.API.Controller.Config;
using Helpline.Common.Constants;
using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Services.Users.ApplicationUsers.Commands;
using Helpline.Services.Users.ApplicationUsers.Queries;
using Helpline.API.Controller.Contracts.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.API.Controller.v1.UserService
{
    [ApiController]
    [Route($"{HelplineRoutes.UserControllerRoute}")]
    public partial class UserServicesController : BaseController
    {
        public UserServicesController(IMediator sender) : base(sender) { }

        [HttpGet]
        [Route(HelplineRoutes.GetUsersRoute)]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var query = new UsersQuery();

            Result<IEnumerable<ApplicationUser>> response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
        }

        [HttpGet]
        [Route(HelplineRoutes.UserRouteById)]
        public async Task<IActionResult> GetUserById(Guid userId, CancellationToken cancellationToken)
        {
            var query = new UserByIdQuery(userId);

            Result<UserResponse> response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
        }

        [HttpPut]
        [Route(HelplineRoutes.UserRoutePermissionsById)]
        public async Task<IActionResult> UpdatePermissions(
            Guid userId,
            [FromBody] UpdateUserPermissionsRequest userRequest,
            CancellationToken cancellationToken)
        {
            if (userRequest is null || !ModelState.IsValid)
                return BadRequest("Invalid patch document.");

            var command = new UserPermissionsUpdateCommand(
                userId,
                userRequest.RoleType,
                userRequest.PermissionType);

            Result result = await Sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }

            return NoContent();
        }

        [HttpPost]
        [Route(HelplineRoutes.UserRoute)]
        public async Task<IActionResult> RegisterUserProfile(
            [FromBody] RegisterUserWithAddressRequest userRequest,
            CancellationToken cancellationToken)
        {
            if (userRequest == null)
                return BadRequest("User data required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new UserCreateCommand(
                userRequest.FirstName,
                userRequest.LastName,
                userRequest.PhoneNumber,
                userRequest.AddressRequest);

            Result<Guid> result = await Sender.Send(command, cancellationToken);

            if (result.IsFailure) return HandleFailure(result);

            return CreatedAtAction(
                nameof(RegisterUserProfile),
                new { userId = result.Value },
                result.Value);
        }

        [HttpPut]
        [Route(HelplineRoutes.UserRouteById)]
        public async Task<IActionResult> UpdateUser(
            Guid userId,
            [FromBody] UpdateUserRequest user,
            CancellationToken cancellationToken)
        {
            if (user == null || !ModelState.IsValid)
                return BadRequest("User data bad request.");

            var command = new UserUpdateCommand(
                userId,
                user.FirstName,
                user.LastName,
                user.PhoneNumber,
                user.SecondPhone);

            Result result = await Sender.Send(command, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : NoContent();
        }
    }
}
