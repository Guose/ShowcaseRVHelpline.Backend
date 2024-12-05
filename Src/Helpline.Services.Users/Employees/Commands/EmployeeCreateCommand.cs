using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.Employees.Commands
{
    public sealed record EmployeeCreateCommand(
        Guid UserId,
        string Company,
        string JobTitle,
        string ReferralCode) : ICommand;
}
