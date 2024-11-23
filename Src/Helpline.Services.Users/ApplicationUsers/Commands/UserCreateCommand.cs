using Helpline.Contracts.v1.Requests;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.ApplicationUsers.Commands
{
    public sealed record UserCreateCommand(
        string FirstName,
        string LastName,
        string PhoneNumber,
        AddressRequest Address) : ICommand<Guid>;
}
