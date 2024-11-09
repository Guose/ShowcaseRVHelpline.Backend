using AutoMapper;
using Helpline.Domain.Data;
using Helpline.UserServices.DTOs.Responses;
using MediatR;

namespace Helpline.UserServices.Queries.QueryHandlers
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, UserResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.UserRepo.GetEntityByIdAsync(request.UserId);

            return mapper.Map<UserResponse>(user);
        }
    }
}
