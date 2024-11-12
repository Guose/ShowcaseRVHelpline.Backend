﻿using Helpline.Common.Constants;
using Helpline.Common.Shared;
using Helpline.Contracts.v1.Responses;
using Helpline.UserServices.ApplicationUsers.Commands;
using Helpline.UserServices.ApplicationUsers.Queries;
using Helpline.WebAPI.Controller.Configuration;
using Helpline.WebAPI.Controller.v1.ApplicationUsers.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.v1.ApplicationUsers
{
    [ApiController]
    [Route($"{HelplineRoutes.UserControllerRoute}")]
    public class UserServicesController : BaseController
    {
        public UserServicesController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        [Route(HelplineRoutes.GetUsersRoute)]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var query = new UsersQuery();

            Result<IEnumerable<UserResponse>> response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
        }

        [HttpGet]
        [Route(HelplineRoutes.UserRouteById)]
        public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            var query = new UserByIdQuery(id);

            Result<UserResponse> response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
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
                userRequest.RequestAddress.Address);

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
