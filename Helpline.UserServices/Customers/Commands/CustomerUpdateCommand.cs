using Helpline.Common.Types;
using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Customers.Commands
{
    public sealed record CustomerUpdateCommand(
        Guid UserId,
        Guid SubscriptionId,
        SubscriptionType SubscriptionType,
        bool SubscriptionStatus) : ICommand<Guid>;
}
