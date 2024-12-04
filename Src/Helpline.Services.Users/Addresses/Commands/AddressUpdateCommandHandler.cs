using AutoMapper;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Data;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Errors;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.Addresses.Commands
{
    public class AddressUpdateCommandHandler : ICommandHandler<AddressUpdateCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IAddressRepository addressRepo;
        private readonly IApplicationUserRepository userRepo;

        public AddressUpdateCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IAddressRepository addressRepo,
            IApplicationUserRepository userRepo)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.addressRepo = addressRepo;
            this.userRepo = userRepo;
        }

        public async Task<Result> Handle(AddressUpdateCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await userRepo.GetEntityByIdAsync(request.UserId.ToString(), cancellationToken);

            if (userToUpdate is null)
            {
                return Result.Failure(DomainErrors.User.NotFound(request.UserId));
            }

            var address = AddressRequest.Create(
                request.Address1,
                request.Address2,
                request.City,
                request.State,
                request.PostalCode);

            var result = await addressRepo.CreateEntityAsync(mapper.Map<Address>(address), cancellationToken);

            if (!result)
            {
                return Result.Failure(new Error("Address.Create", "Failed to create new Address for user."));
            }

            return await unitOfWork.CompleteAsync(cancellationToken) ?
                Result.Success(result) :
                Result.Failure(
                    new Error(
                        "UpdateUserInfo.Address",
                        "Couldn't save address to the database"));
        }
    }
}
