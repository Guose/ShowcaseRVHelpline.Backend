using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Employees.Commands
{
    public sealed record EmployeeUpdateCommand(
        Guid UserId,
        bool IsActive,
        List<string> Attachments) : ICommand;
}
