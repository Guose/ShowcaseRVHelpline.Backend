using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Subscriptions.Customers.Commands
{
    public sealed record CustomerUpdateStatusCommand(
        Guid UserId,
        bool SubscriptionStatus,
        bool IsActive) : ICommand<Guid>;
}
