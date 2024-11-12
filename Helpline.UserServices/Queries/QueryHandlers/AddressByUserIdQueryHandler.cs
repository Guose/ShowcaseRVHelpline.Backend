using AutoMapper;
using Helpline.Common.Errors;
using Helpline.Common.Shared;
using Helpline.Domain.Data;
using Helpline.Domain.Messaging;
using Helpline.UserServices.DTOs.Responses;

namespace Helpline.UserServices.Queries.QueryHandlers
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
            {
                return Result.Failure<AddressResponse>(CommonErrors.User.NotFound(request.UserId));
            }

            var address = await unitOfWork.AddressRepo.GetEntityByIdAsync((int)user.AddressId!, cancellationToken);
            if (address == null)
            {
                return Result.Failure<AddressResponse>(CommonErrors.Address.NotFound);
            }

            return mapper.Map<AddressResponse>(address);
        }
    }
}
