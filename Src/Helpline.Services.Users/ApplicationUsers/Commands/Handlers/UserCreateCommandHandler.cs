using AutoMapper;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Data;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.ApplicationUsers.Commands.Handlers
{
    internal sealed class UserCreateCommandHandler : ICommandHandler<UserCreateCommand, Guid>
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
            var address = AddressRequest.Create(
                request.Address.Address1,
                request.Address.Address2!,
                request.Address.City!,
                request.Address.State!,
                request.Address.PostalCode);

            var user = UserRequest.Create(
                Guid.NewGuid(),
                request.FirstName,
                request.LastName,
                request.PhoneNumber);

            await unitOfWork.UserRepo.CreateEntityAsync(mapper.Map<ApplicationUser>(user), cancellationToken);

            await unitOfWork.CompleteAsync(cancellationToken);

            return user.Id;
        }
    }
}
