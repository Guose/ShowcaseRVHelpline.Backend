using Helpline.Domain.Models.CoreElements;

namespace Helpline.Domain.Events
{
    public abstract record DomainEvent(Guid Id) : IDomainEvent;
}
