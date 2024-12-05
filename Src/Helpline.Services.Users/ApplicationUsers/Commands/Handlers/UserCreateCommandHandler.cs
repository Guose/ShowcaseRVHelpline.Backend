using AutoMapper;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Data;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Errors;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.ApplicationUsers.Commands.Handlers
{
    internal sealed class UserCreateCommandHandler : ICommandHandler<UserCreateCommand, Guid>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IApplicationUserRepository userRepo;

        public UserCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IApplicationUserRepository userRepo)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userRepo = userRepo;
        }

        public async Task<Result<Guid>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var address = AddressRequest.Create(
                request.Address.Address1,
                request.Address.Address2!,
                request.Address.City!,
                request.Address.State!,
                request.Address.PostalCode);

            Guid id = Guid.NewGuid();
            var user = UserRequest.Create(
                id,
                request.FirstName,
                request.LastName,
                request.PhoneNumber);

            var response = mapper.Map<ApplicationUser>(user);

            if (response is null)
                return Result.Failure<Guid>(DomainErrors.Map.MappingError);

            if (!await userRepo.CreateEntityAsync(response, cancellationToken))
                return Result.Failure<Guid>(DomainErrors.User.CreateError(id));

            await unitOfWork.CompleteAsync(cancellationToken);

            return user.Id;
        }
    }
}
