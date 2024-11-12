using Helpline.Domain.Messaging;
using Helpline.UserServices.DTOs.Requests;

namespace Helpline.UserServices.Commands
{
    public sealed record UserCreateCommand(
        string FirstName,
        string LastName,
        string PhoneNumber,
        AddressRequest Address) : ICommand<Guid>;
}
