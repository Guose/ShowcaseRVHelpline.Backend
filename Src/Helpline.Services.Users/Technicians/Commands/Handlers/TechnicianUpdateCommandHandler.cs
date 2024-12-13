using AutoMapper;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Data;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Errors;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.Technicians.Commands.Handlers
{
    public class TechnicianUpdateCommandHandler : ICommandHandler<TechnicianUpdateCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ITechnicianRepository techRepo;

        public TechnicianUpdateCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ITechnicianRepository techRepo)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.techRepo = techRepo;
        }

        public async Task<Result> Handle(TechnicianUpdateCommand request, CancellationToken cancellationToken)
        {
            var technician = await techRepo.GetTechnicianByUserIdAsync(request.UserId.ToString(), cancellationToken);

            if (technician is null)
                return Result.Failure(DomainErrors.User.NotFound(request.UserId));

            var updateTech = TechnicianRequest.Create(
                request.Company,
                request.ReferralCode,
                request.IsW9OnFile,
                request.Website);

            var result = mapper.Map<Technician>(updateTech);

            if (result is null)
                return Result.Failure(
                    new Error(
                        "Technician.Mapping",
                        "Failed to map TechnicianRequest to Technician."));

            var updateResult = await techRepo.UpdateEntityAsync(result, cancellationToken);

            if (updateResult.IsFailure)
                return Result.Failure<Guid>(
                    new Error(
                        "Technician.UpdateUserInfo",
                        $"UpdateUserInfo to technician profile {request.UserId} could not be completed."));

            await unitOfWork.CompleteAsync(cancellationToken);

            return Result.Success();
        }
    }
}
