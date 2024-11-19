using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Messaging;

namespace Helpline.UserServices.ApplicationUsers.Commands
{
    public sealed record UserCreateCommand(
        string FirstName,
        string LastName,
        string PhoneNumber,
        AddressRequest Address) : ICommand<Guid>;
}
