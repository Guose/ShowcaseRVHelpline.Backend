using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Customers.Commands
{
    public sealed record CustomerUpdateCommand(Guid UserId, bool SubscriptionStatus) : ICommand<bool>;
}
