using Helpline.Common.Essentials;

namespace Helpline.Domain.Events
{
    public abstract record DomainEvent(Guid Id) : ICommonEvent;
}
