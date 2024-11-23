using AutoMapper;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Data;
using Helpline.Domain.Errors;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.ApplicationUsers.Commands.Handlers
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
                return Result.Failure(DomainErrors.User.NotFound(request.UserId));

            var updatedUser = UserRequest.Update(
                request.UserId,
                request.FirstName,
                request.LastName,
                request.PhoneNumber,
                request.SecondaryPhone,
                DateTime.Now);

            var result = mapper.Map<ApplicationUser>(updatedUser);

            //user.FirstName = updatedUser.FirstName;
            //user.LastName = updatedUser.LastName;
            //user.PhoneNumber = updatedUser.PhoneNumber;
            //user.SecondaryPhone = updatedUser.SecondaryPhone;
            //user.LastModifiedOn = updatedUser.LastModifiedOn;

            await unitOfWork.UserRepo.UpdateEntityAsync(result, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            return Result.Success();
        }
    }
}
