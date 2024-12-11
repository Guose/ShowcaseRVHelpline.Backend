using Helpline.API.Controller.Config;
using Helpline.Common.Constants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.API.Controller.v1.ServiceCallHub
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
