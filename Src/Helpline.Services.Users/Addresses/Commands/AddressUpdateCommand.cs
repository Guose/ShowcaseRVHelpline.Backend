using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.Addresses.Commands
{
    public sealed record AddressUpdateCommand(
        Guid UserId,
        string Address1,
        string Address2,
        string City,
        string State,
        string PostalCode) : ICommand;
}
