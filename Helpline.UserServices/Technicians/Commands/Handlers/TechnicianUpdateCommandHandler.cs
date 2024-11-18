using AutoMapper;
using Helpline.Common.Errors;
using Helpline.Common.Models;
using Helpline.Common.Shared;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Data;
using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Technicians.Commands.Handlers
{
    public class TechnicianUpdateCommandHandler : ICommandHandler<TechnicianUpdateCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TechnicianUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result> Handle(TechnicianUpdateCommand request, CancellationToken cancellationToken)
        {
            var technician = await unitOfWork.TechnicianRepo.GetTechnicianByUserIdAsync(request.UserId.ToString(), cancellationToken);

            if (technician is null)
            {
                return Result.Failure(CommonErrors.User.NotFound(request.UserId));
            }

            var updateTech = TechnicianRequest.Create(
                request.Company,
                request.ReferralCode,
                request.IsW9OnFile,
                request.Website);

            var response = mapper.Map<Technician>(updateTech);

            if (!await unitOfWork.TechnicianRepo.UpdateEntityAsync(response, cancellationToken) &&
                !await unitOfWork.CompleteAsync(cancellationToken))
            {
                return Result.Failure<Guid>(new Error("Technician.Update", $"Update to technician profile {request.UserId} could not be completed."));
            }

            return Result.Success();
        }
    }
}
