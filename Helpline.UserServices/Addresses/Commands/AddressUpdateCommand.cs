using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Addresses.Commands
{
    public sealed record AddressUpdateCommand(Guid UserId, AddressRequest Address) : ICommand;
}
