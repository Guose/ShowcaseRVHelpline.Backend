using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.ApplicationUsers.Commands
{
    public sealed record UserUpdateCommand(
        Guid UserId,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string SecondaryPhone) : ICommand;
}
