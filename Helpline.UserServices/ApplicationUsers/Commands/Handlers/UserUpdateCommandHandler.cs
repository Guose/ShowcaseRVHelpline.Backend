using AutoMapper;
using Helpline.Common.Errors;
using Helpline.Common.Shared;
using Helpline.Domain.Data;
using Helpline.Domain.Messaging;

namespace Helpline.UserServices.ApplicationUsers.Commands.Handlers
{
    public class UserUpdateCommandHandler : ICommandHandler<UserUpdateCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.UserRepo.GetEntityByIdAsync(request.UserId.ToString(), cancellationToken);

            if (user is null)
                return Result.Failure(CommonErrors.User.NotFound(request.UserId));

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
            user.SecondaryPhone = request.SecondaryPhone;

            await unitOfWork.UserRepo.UpdateEntityAsync(user, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            return Result.Success();
        }
    }
}
