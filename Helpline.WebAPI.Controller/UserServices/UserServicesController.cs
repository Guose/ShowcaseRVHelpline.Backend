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
    public class UserServicesController : BaseController
    {
        public UserServicesController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        [HttpGet("Customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await unitOfWork.CustomerRepo.GetAllEntitiesAsync();

            if (customers == null)
                return NotFound();

            return Ok(mapper.Map<IEnumerable<CustomerResponse>>(customers));
        }

        [HttpGet("Customer/{id}")]
        public async Task<IActionResult> GetCustomerByUserId(int id)
        {
            var customer = await unitOfWork.CustomerRepo.GetEntityByIdAsync(id);

            if (customer == null)
                return NotFound();

            return Ok(mapper.Map<CustomerResponse>(customer));
        }

        [HttpPost("Customer")]
        public async Task<IActionResult> CreateCustomerUserRequest([FromBody] CustomerRequest customer)
        {
            if (customer == null)
                return BadRequest("Customer data required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerResult = mapper.Map<Customer>(customer);
            var userResult = mapper.Map<ApplicationUser>(customer.User);

            var result = await unitOfWork.UserRepo.CreateNewUserEntityAsync(userResult, customerResult);
            if (!result.Success)
                return BadRequest(result.Message);

            await unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(CreateCustomerUserRequest), new { userId = customerResult.UserId }, customer);
        }

    }
}
