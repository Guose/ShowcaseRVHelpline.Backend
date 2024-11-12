using Helpline.Common.Constants;
using Helpline.Common.Shared;
using Helpline.UserServices.DTOs.Responses;
using Helpline.UserServices.Queries;
using Helpline.WebAPI.Controller.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.v1.ApplicationUsers
{
    [ApiController]
    [Route($"{HelplineConfig.AddressControllerRoute}")]
    public class AddressController : BaseController
    {
        public AddressController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        [Route($"{HelplineConfig.AddressRoute}")]
        public async Task<IActionResult> GetUserAddress(Guid userId, CancellationToken cancellationToken)
        {
            var query = new AddressByUserIdQuery(userId);

            Result<AddressResponse> response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }
    }
}
