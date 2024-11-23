using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.Employees.Commands
{
    public sealed record EmployeeUpdateCommand(
        Guid UserId,
        bool IsActive,
        List<string> Attachments) : ICommand;
}
