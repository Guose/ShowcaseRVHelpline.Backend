using Helpline.Domain.Messaging;

namespace Helpline.SubscriptionServices.Customers.Commands
{
    public sealed record CustomerUpdateStatusCommand(
        Guid UserId,
        bool SubscriptionStatus,
        bool IsActive) : ICommand<Guid>;
}
