using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Commands
{
    public sealed record AddressCreateCommand(
        string Address1,
        string Address2,
        string City,
        string State,
        string PostalCode) : ICommand<int>;
}
