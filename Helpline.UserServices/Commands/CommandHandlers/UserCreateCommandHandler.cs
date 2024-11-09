﻿using AutoMapper;
using Helpline.Common.Errors;
using Helpline.Common.Models;
using Helpline.Common.Shared;
using Helpline.Domain.Data;
using Helpline.Domain.Messaging;
using Helpline.Domain.ValueObjects;
using Helpline.UserServices.DTOs.Requests;

namespace Helpline.UserServices.Commands.CommandHandlers
{
    public sealed class UserCreateCommandHandler : ICommandHandler<UserCreateCommand, Guid>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            Result<PhoneNumber> phoneResult = PhoneNumber.Create(request.PhoneNumber);
            Result<FirstName> firstNameResult = FirstName.Create(request.FirstName);
            Result<LastName> lastNameResult = LastName.Create(request.LastName);

            if (phoneResult.IsFailure || firstNameResult.IsFailure || lastNameResult.IsFailure)
            {
                return Result.Failure<Guid>(CommonErrors.User.AreNull);
            }

            var address = AddressRequest.Create(
                request.Address.Address1,
                request.Address.Address2!,
                request.Address.City!,
                request.Address.State!,
                request.Address.PostalCode);

            var user = UserRequest.Create(
                request.UserId,
                firstNameResult.Value,
                lastNameResult.Value,
                phoneResult.Value,
                address);

            await unitOfWork.AddressRepo.CreateEntityAsync(mapper.Map<Address>(address), cancellationToken);
            await unitOfWork.UserRepo.CreateEntityAsync(mapper.Map<ApplicationUser>(request), cancellationToken);

            await unitOfWork.CompleteAsync(cancellationToken);

            return user.GuidId;
        }
    }
}
