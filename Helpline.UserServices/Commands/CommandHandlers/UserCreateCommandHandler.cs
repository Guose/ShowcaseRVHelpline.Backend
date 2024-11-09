using AutoMapper;
using Helpline.Common.Models;
using Helpline.Domain.Data;
using Helpline.UserServices.DTOs.Responses;
using MediatR;

namespace Helpline.UserServices.Commands.CommandHandlers
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommandRequest, UserResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<UserResponse> Handle(UserCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var userResult = mapper.Map<ApplicationUser>(request.UserRequest);
            var addressResult = mapper.Map<Address>(request.UserRequest.Address);

            await unitOfWork.UserRepo.CreateEntityAsync(userResult);
            await unitOfWork.AddressRepo.CreateEntityAsync(addressResult);
            await unitOfWork.CompleteAsync();

            return mapper.Map<UserResponse>(userResult);
        }
    }
}
