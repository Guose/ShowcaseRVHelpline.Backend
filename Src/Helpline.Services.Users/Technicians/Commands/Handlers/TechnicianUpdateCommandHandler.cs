﻿using AutoMapper;
using FluentValidation;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Data;
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
                return Result.Failure(DomainErrors.User.NotFound(request.UserId));
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
                return Result.Failure<Guid>(new Error("Technician.UpdateUserInfo", $"UpdateUserInfo to technician profile {request.UserId} could not be completed."));
            }

            return Result.Success();
        }
    }
}
