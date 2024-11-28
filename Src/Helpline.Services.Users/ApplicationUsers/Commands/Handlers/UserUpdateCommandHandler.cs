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
    internal sealed class UserUpdateCommandHandler : ICommandHandler<UserUpdateCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IApplicationUserRepository userRepo;
        private readonly IMapper mapper;

        public UserUpdateCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IApplicationUserRepository userRepo)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userRepo = userRepo;
        }

        public async Task<Result> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepo.GetByIdWithNoTrackingToUpdateUserProfileAsync(request.UserId, cancellationToken);

            if (user is null || string.IsNullOrEmpty(user.Id))
                return Result.Failure(DomainErrors.User.NotFound(request.UserId));

            var updatedUser = UserRequest.UpdateUserInfo(
                request.UserId,
                request.FirstName,
                request.LastName,
                request.PhoneNumber,
                request.SecondaryPhone);

            var result = mapper.Map<ApplicationUser>(updatedUser);

            if (result is null)
            {
                return Result.Failure(new Error("User.Mapping", "Failed to map UserRequest to ApplicationUser."));
            }

            if (!await userRepo.UpdateEntityAsync(result, cancellationToken))
                return Result.Failure(new Error("User.Updated", "User could not be updated."));

            await unitOfWork.CompleteAsync(cancellationToken);

            return Result.Success();

        }
    }
}
