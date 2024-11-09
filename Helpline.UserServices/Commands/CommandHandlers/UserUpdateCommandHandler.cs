using AutoMapper;
using Helpline.Common.Models;
using Helpline.Domain.Data;
using MediatR;

namespace Helpline.UserServices.Commands.CommandHandlers
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommandRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(UserUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.UserRepo.GetEntityByIdAsync(request.UserId);
            var result = mapper.Map(request.UserRequest, user);

            if (!await unitOfWork.UserRepo.UpdateEntityAsync(result))
                return false;

            
            if (!await unitOfWork.CompleteAsync())
                return false;

            return true;
        }
    }
}
