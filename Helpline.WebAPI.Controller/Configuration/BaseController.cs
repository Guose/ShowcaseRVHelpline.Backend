using AutoMapper;
using Helpline.Domain.Data;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.Configuration
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
}
