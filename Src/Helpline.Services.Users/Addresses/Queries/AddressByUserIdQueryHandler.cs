using AutoMapper;
using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Data;
using Helpline.Domain.Errors;
using Helpline.Domain.Shared;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.Addresses.Queries
{
    public class AddressByUserIdQueryHandler : IQueryHandler<AddressByUserIdQuery, AddressResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddressByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<AddressResponse>> Handle(AddressByUserIdQuery request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.UserRepo.GetEntityByIdAsync(request.UserId.ToString(), cancellationToken);

            if (user == null)
                return Result.Failure<AddressResponse>(DomainErrors.User.NotFound(request.UserId));

            var address = await unitOfWork.AddressRepo.GetEntityByIdAsync(user.Address!.Id, cancellationToken);

            if (address == null)
                return Result.Failure<AddressResponse>(DomainErrors.Address.NotFound);

            return mapper.Map<AddressResponse>(address);
        }
    }
}
