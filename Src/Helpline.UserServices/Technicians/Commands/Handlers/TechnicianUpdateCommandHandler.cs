using AutoMapper;
using FluentValidation;
using Helpline.Common.Errors;
using Helpline.Common.Shared;
using Helpline.Contracts.v1.Requests;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data;
using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Technicians.Commands.Handlers
{
    public class TechnicianUpdateCommandHandler : ICommandHandler<TechnicianUpdateCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IValidator<TechnicianUpdateCommand> validator;

        public TechnicianUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<TechnicianUpdateCommand> validator)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<Result> Handle(TechnicianUpdateCommand request, CancellationToken cancellationToken)
        {
            var validateResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validateResult.IsValid)
            {
                return Result.Failure((Error)validateResult.Errors.Select(e => e.ErrorMessage));
            }

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
