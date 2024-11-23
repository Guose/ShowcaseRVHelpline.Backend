using Helpline.Common.Constants;
using Helpline.Contracts.v1.Requests;
using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Shared;
using Helpline.Services.Users.Technicians.Commands;
using Helpline.Services.Users.Technicians.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.WebAPI.Controller.v1.UserService
{
    public partial class UserServicesController
    {
        [HttpGet]
        [Route(HelplineRoutes.GetTechniciansRoute)]
        public async Task<IActionResult> GetAllTechnicians(CancellationToken cancellationToken)
        {
            var query = new TechniciansAllQuery();

            Result<IEnumerable<TechnicianResponse>> response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
        }

        [HttpGet]
        [Route(HelplineRoutes.TechnicianRouteById)]
        public async Task<IActionResult> GetTechnicianByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var query = new TechnicianByUserIdQuery(userId);

            Result<TechnicianResponse> response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
        }

        [HttpPut]
        [Route(HelplineRoutes.TechnicianRouteById)]
        public async Task<IActionResult> UpdateTechnicianByUserId(Guid userId, [FromBody] TechnicianRequest request, CancellationToken cancellationToken)
        {
            var command = new TechnicianUpdateCommand(
                userId,
                request.Company,
                request.ReferralCode,
                request.IsW9OnFile,
                request.Website);

            Result result = await Sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }

            return NoContent();
        }
    }
}
