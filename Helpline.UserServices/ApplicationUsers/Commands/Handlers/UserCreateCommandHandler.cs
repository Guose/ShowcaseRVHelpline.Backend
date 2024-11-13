using AutoMapper;
using Helpline.Common.Models;
using Helpline.Common.Shared;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Data;
using Helpline.Domain.Messaging;
using Helpline.Domain.ValueObjects;

namespace Helpline.UserServices.ApplicationUsers.Commands.Handlers
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
                return Result.Failure<Guid>(new Error("User.Create", "Validation failed for user data."));
            }

            var address = AddressRequest.Create(
                request.Address.Address1,
                request.Address.Address2!,
                request.Address.City!,
                request.Address.State!,
                request.Address.PostalCode);

            await unitOfWork.AddressRepo.CreateEntityAsync(mapper.Map<Address>(address), cancellationToken);

            var user = UserRequest.Create(
                Guid.NewGuid(),
                request.FirstName,
                request.LastName,
                request.PhoneNumber,
                address);

            await unitOfWork.UserRepo.CreateEntityAsync(mapper.Map<ApplicationUser>(request), cancellationToken);

            await unitOfWork.CompleteAsync(cancellationToken);

            return user.GuidId;
        }
    }
}
