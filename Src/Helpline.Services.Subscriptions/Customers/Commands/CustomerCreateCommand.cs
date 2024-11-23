using Helpline.Contracts.v1.Requests;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Subscriptions.Customers.Commands
{
    public sealed record CustomerCreateCommand(
        Guid UserId,
        CustomerRequest Customer) : ICommand<Guid>;
}
