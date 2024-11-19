using AutoMapper;
using Helpline.Common.Shared;
using Helpline.Contracts.v1.Requests;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data;
using Helpline.Domain.Messaging;

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
                request.PhoneNumber,
                DateTime.Now);

            await unitOfWork.UserRepo.CreateEntityAsync(mapper.Map<ApplicationUser>(user), cancellationToken);

            await unitOfWork.CompleteAsync(cancellationToken);

            return user.GuidId;
        }
    }
}
