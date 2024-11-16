using Helpline.Common.Constants;
using Helpline.Common.Shared;
using Helpline.Contracts.v1.Responses;
using Helpline.UserServices.Employees.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.v1.UserService
{
    public partial class UserServicesController
    {
        [HttpGet]
        [Route(HelplineRoutes.EmployeeRouteById)]
        public async Task<IActionResult> GetEmployeeByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var query = new EmployeeByUserIdQuery(userId);

            Result<EmployeeResponse> response = await Sender.Send(query);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
        }
    }
}
