using AutoMapper;
using Helpline.Domain.Data;
using Helpline.UserServices.Aggregator;
using MediatR;

namespace Helpline.UserServices.Commands.CommandHandlers
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommandRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(UserDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.UserRepo.GetEntityByIdAsync(request.UserId);            

            if (user == null || !await unitOfWork.UserRepo.DeleteEntityAsync(user))
                return false;

            var address = await unitOfWork.AddressRepo.GetEntityByIdAsync(user.AddressId);

            if (address == null || !await unitOfWork.AddressRepo.DeleteEntityAsync(address))
                return false;

            var entity = await UsersEntityHandler.GetUserEntityByUserIdAsync(user.Role, user.Id, unitOfWork);

            if (entity == null || !await UsersEntityHandler.HandleUserEntityAsync(entity, unitOfWork, "delete"))
                return false;

            await unitOfWork.CompleteAsync();

            return true;
        }
    }
}
