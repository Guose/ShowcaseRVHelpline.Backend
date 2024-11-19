using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Messaging;

namespace Helpline.SubscriptionServices.Customers.Commands
{
    public sealed record CustomerCreateCommand(
        Guid UserId,
        CustomerRequest Customer) : ICommand<Guid>;
}
