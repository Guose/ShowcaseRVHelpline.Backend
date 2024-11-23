using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.Technicians.Commands
{
    public sealed record TechnicianUpdateCommand(
        Guid UserId,
        string Company,
        string ReferralCode,
        bool IsW9OnFile,
        string Website) : ICommand;
}
