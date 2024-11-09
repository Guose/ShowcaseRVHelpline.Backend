using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Commands
{
    public sealed record UserUpdateCommand(
        Guid UserId,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string SecondPhone) : ICommand;
}
