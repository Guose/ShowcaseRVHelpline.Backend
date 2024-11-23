using Helpline.Common.Constants;
using Helpline.Contracts.v1.Requests;
using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Shared;
using Helpline.Services.Subscriptions.Customers.Commands;
using Helpline.Services.Subscriptions.Customers.Queries;
using Helpline.WebAPI.Controller.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.v1.SubscriptionService
{
    [ApiController]
    [Route(HelplineRoutes.SubscriptionControllerRoute)]
    public class CustomerController : BaseController
    {
        public CustomerController(IMediator sender) : base(sender) { }

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
            [FromBody] CustomerRequest request,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest("User data bad request.");

            var command = new CustomerUpdateStatusCommand(
                userId,
                request.SubscriptionStatus,
                request.IsActive);

            Result result = await Sender.Send(command, cancellationToken);

            return result.IsFailure ? HandleFailure(result) : NoContent();
        }
    }
}
