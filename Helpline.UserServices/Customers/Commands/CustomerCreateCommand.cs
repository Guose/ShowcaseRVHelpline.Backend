using Helpline.Common.Types;
using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Customers.Commands
{
    public sealed record CustomerCreateCommand(
        Guid UserId,
        Guid SubscriptionId,
        SubscriptionType SubscriptionType,
        DateTime SubscriptionStartDate) : ICommand<Guid>;
}
