using Helpline.Common.Constants;
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
        public Task<IActionResult> GetUserAddress(string userId)
        {
            //var user = await unitOfWork.UserRepo.GetEntityByIdAsync(userId);

            //if (user == null)
            //    return NotFound("User not found");

            //var address = await unitOfWork.AddressRepo.GetEntityByIdAsync(user.AddressId);

            //if (address == null)
            //    return NotFound("Address for user not found");

            //var result = mapper.Map<AddressResponse>(address);

            return Ok();
        }
    }
}
