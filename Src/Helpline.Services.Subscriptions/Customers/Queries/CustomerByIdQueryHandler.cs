using AutoMapper;
using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Data;
using Helpline.Domain.Errors;
using Helpline.Domain.Shared;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Subscriptions.Customers.Queries
{
    public class CustomerByIdQueryHandler : IQueryHandler<CustomerByIdQuery, CustomerResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<CustomerResponse>> Handle(CustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await unitOfWork.CustomerRepo.GetCustomerByUserIdAsync(request.UserId.ToString(), cancellationToken);

            if (customer == null)
            {
                Result.Failure(DomainErrors.User.NotFound(request.UserId));
            }

            var response = mapper.Map<CustomerResponse>(customer);

            return response;
        }
    }
}
