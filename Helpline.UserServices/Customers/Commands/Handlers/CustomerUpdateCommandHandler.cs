using AutoMapper;
using Helpline.Common.Shared;
using Helpline.Domain.Data;
using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Customers.Commands.Handlers
{
    public class CustomerUpdateCommandHandler : ICommandHandler<CustomerUpdateCommand, Guid>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CustomerUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var customer = await unitOfWork.CustomerRepo.GetCustomerByUserIdAsync(request.UserId.ToString(), cancellationToken);

            if (customer == null)
            {
                Result.Failure(new Error("Customer.Failure", "Customer has not been created yet..."));
            }
            customer!.SubscriptionStatus = request.SubscriptionStatus;

            return (await unitOfWork.CustomerRepo.UpdateEntityAsync(customer, cancellationToken) &&
            await unitOfWork.CompleteAsync(cancellationToken)) ?
            Result.Success(Guid.Parse(customer.UserId)) :
            Result.Failure<Guid>(new Error("Customer.Update", $"Could not update and save Customer with UserId: {customer.UserId}"));
        }
    }
}
