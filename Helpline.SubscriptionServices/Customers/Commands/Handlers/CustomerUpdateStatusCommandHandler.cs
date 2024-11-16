using AutoMapper;
using Helpline.Common.Shared;
using Helpline.Domain.Data;
using Helpline.Domain.Messaging;

namespace Helpline.SubscriptionServices.Customers.Commands.Handlers
{
    public class CustomerUpdateStatusCommandHandler : ICommandHandler<CustomerUpdateStatusCommand, Guid>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerUpdateStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CustomerUpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var customer = await unitOfWork.CustomerRepo.GetCustomerByUserIdAsync(request.UserId.ToString(), cancellationToken);

            if (customer == null)
            {
                return Result.Failure<Guid>(new Error("Customer.Failure", "Customer has not been created yet..."));
            }

            if (customer.SubscriptionEndDate < DateTime.UtcNow)
            {
                customer.SubscriptionStatus = !customer.SubscriptionStatus;
                customer.IsActive = request.IsActive;
                customer.ModifiedOn = DateTime.UtcNow;
                return Result.Failure<Guid>(new Error("", ""));
            }



            return await unitOfWork.CustomerRepo.UpdateEntityAsync(customer, cancellationToken) &&
            await unitOfWork.CompleteAsync(cancellationToken) ?
            Result.Success(Guid.Parse(customer.UserId)) :
            Result.Failure<Guid>(new Error("Customer.Update", $"Could not update and save Customer with UserId: {request.UserId}"));
        }
    }
}
