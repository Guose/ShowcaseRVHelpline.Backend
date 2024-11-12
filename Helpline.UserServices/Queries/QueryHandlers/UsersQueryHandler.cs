using AutoMapper;
using Helpline.Common.Shared;
using Helpline.Domain.Data;
using Helpline.Domain.Messaging;
using Helpline.UserServices.DTOs.Responses;

namespace Helpline.UserServices.Queries.QueryHandlers
{
    public sealed class GetAllUsersHandler : IQueryHandler<UsersQuery, IEnumerable<UserResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllUsersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<IEnumerable<UserResponse>>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            var users = await unitOfWork.UserRepo.GetAllEntitiesAsync(cancellationToken);

            if (users is null)
            {
                return Result.Failure<IEnumerable<UserResponse>>(new Error(
                    "Users.NotFound",
                    "There are no users to be retrieved"));
            }

            var response = mapper.Map<IEnumerable<UserResponse>>(users);

            return Result.Success(response);
        }
    }
}
