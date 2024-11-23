using Helpline.Common.Constants;
using Helpline.WebAPI.Controller.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.v1.ServiceCallHub
{
    [ApiController]
    [Route(HelplineRoutes.ServiceCaseControllerRoute)]
    public class ServiceCaseController : BaseController
    {
        public ServiceCaseController(IMediator sender) : base(sender)
        {
        }
    }
}
