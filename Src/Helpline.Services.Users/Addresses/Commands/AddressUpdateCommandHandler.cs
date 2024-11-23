using AutoMapper;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Data;
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

        public AddressUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result> Handle(AddressUpdateCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await unitOfWork.UserRepo.GetEntityByIdAsync(request.UserId.ToString(), cancellationToken);

            if (userToUpdate == null)
            {
                return Result.Failure(CommonErrors.User.NotFound(request.UserId));
            }

            var address = AddressRequest.Create(
                request.Address1,
                request.Address2,
                request.City,
                request.State,
                request.PostalCode);

            var result = await unitOfWork.AddressRepo.CreateEntityAsync(mapper.Map<Address>(address), cancellationToken);

            return await unitOfWork.CompleteAsync(cancellationToken) ?
                Result.Success(result) :
                Result.Failure(new Error("Update.Address", "Couldn't save address to the database"));
        }
    }
}
