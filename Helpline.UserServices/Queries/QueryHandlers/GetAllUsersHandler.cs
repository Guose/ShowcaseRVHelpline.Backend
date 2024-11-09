using AutoMapper;
using Helpline.Domain.Data;
using Helpline.UserServices.DTOs.Responses;
using MediatR;

namespace Helpline.UserServices.Queries.QueryHandlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllUsersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await unitOfWork.UserRepo.GetAllEntitiesAsync();

            return mapper.Map<IEnumerable<UserResponse>>(users);
        }
    }
}
