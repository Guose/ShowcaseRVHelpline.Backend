using AutoMapper;
using Helpline.Common.Shared;
using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Data;
using Helpline.Domain.Messaging;

namespace Helpline.UserServices.ApplicationUsers.Queries.Handlers
{
    public class UserByIdQueryHandler : IQueryHandler<UserByIdQuery, UserResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<UserResponse>> Handle(UserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.UserRepo.GetEntityByIdAsync(request.UserId.ToString(), cancellationToken);

            return mapper.Map<UserResponse>(user);
        }
    }
}
