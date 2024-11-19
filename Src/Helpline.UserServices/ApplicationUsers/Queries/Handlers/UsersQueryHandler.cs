using AutoMapper;
using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Data;
using Helpline.Domain.Errors;
using Helpline.Domain.Messaging;
using Helpline.Domain.Shared;

namespace Helpline.UserServices.ApplicationUsers.Queries.Handlers
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
                return Result.Failure<IEnumerable<UserResponse>>(CommonErrors.User.CollectionNotFound);
            }

            var response = mapper.Map<IEnumerable<UserResponse>>(users);

            return Result.Success(response);
        }
    }
}
