using Helpline.Common.Constants;
using Helpline.Common.Shared;
using Helpline.Contracts.v1.Responses;
using Helpline.UserServices.Customers.Commands;
using Helpline.UserServices.Customers.Queries;
using Helpline.WebAPI.Controller.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.v1.ApplicationUsers
{
    [ApiController]
    [Route(HelplineRoutes.CustomerControllerRoute)]
    public class CustomerController : BaseController
    {
        public CustomerController(ISender sender) : base(sender) { }

        [HttpGet]
        [Route(HelplineRoutes.CustomerByIdRoute)]
        public async Task<IActionResult> GetCustomerByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var query = new CustomerByIdQuery(userId);

            Result<CustomerResponse> response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
        }

        [HttpPut]
        [Route(HelplineRoutes.CustomerByIdRoute)]
        public async Task<IActionResult> UpdateCustomer(
            Guid userId,
            [FromBody] bool subscriptionStatus,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest("User data bad request.");

            var command = new CustomerUpdateCommand(userId, subscriptionStatus);

            Result result = await Sender.Send(command, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : NoContent();
        }
    }
}
