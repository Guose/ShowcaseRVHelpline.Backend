using AutoMapper;
using Helpline.Common.Models;
using Helpline.Domain.Data;
using Helpline.UserServices.DTOs.Requests;
using Helpline.UserServices.DTOs.Responses;
using Helpline.WebAPI.Controller.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.UserServices
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : BaseController
    {
        public AddressController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("/{userId}")]
        public async Task<IActionResult> GetUserAddress(string userId)
        {
            var user = await unitOfWork.UserRepo.GetEntityByIdAsync(userId);

            if (user == null)
                return NotFound("User not found");

            var address = await unitOfWork.AddressRepo.GetEntityByIdAsync(user.AddressId);

            if (address == null) 
                return NotFound("Address for user not found");

            var result = mapper.Map<AddressResponse>(address);

            return Ok(result);
        }
    }
}
