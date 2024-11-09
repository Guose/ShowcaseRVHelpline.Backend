using AutoMapper;
using Helpline.Domain.Data;
using Helpline.WebAPI.Controller.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.v1.ServiceCallHub
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceCaseController : BaseController
    {
        public ServiceCaseController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
