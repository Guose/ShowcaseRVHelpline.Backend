using AutoMapper;
using Helpline.Domain.Data;
using Helpline.WebAPI.Controller.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.v1.ServiceCallHub
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceCaseController : BaseController
    {
        public ServiceCaseController(ISender sender) : base(sender)
        {
        }
    }
}
