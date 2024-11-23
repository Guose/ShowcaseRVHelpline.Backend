using Helpline.Common.Constants;
using Helpline.Contracts.v1.Requests;
using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Shared;
using Helpline.Services.Users.Employees.Commands;
using Helpline.Services.Users.Employees.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.v1.UserService
{
    public partial class UserServicesController
    {
        [HttpGet]
        [Route(HelplineRoutes.GetEmployeesRoute)]
        public async Task<IActionResult> GetAllEmployees(CancellationToken cancellationToken)
        {
            var query = new EmployeesAllQuery();

            Result<IEnumerable<EmployeeResponse>> response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
        }

        [HttpGet]
        [Route(HelplineRoutes.EmployeeRouteById)]
        public async Task<IActionResult> GetEmployeeByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var query = new EmployeeByUserIdQuery(userId);

            Result<EmployeeResponse> response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
        }

        [HttpPut]
        [Route(HelplineRoutes.EmployeeRouteById)]
        public async Task<IActionResult> UpdateEmployeeByUserId(Guid userId, [FromBody] EmployeeRequest request, CancellationToken cancellationToken)
        {
            var command = new EmployeeUpdateCommand(userId, request.IsActive, request.Attachments!.ToList());

            Result result = await Sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }

            return NoContent();
        }
    }
}
