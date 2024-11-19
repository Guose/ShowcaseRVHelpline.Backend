using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Technicians.Commands
{
    public sealed record TechnicianUpdateCommand(
        Guid UserId,
        string Company,
        string ReferralCode,
        bool IsW9OnFile,
        string Website) : ICommand;
}
