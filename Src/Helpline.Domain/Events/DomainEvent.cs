using Helpline.DataAccess.Models.CoreElements;

namespace Helpline.Domain.Events
{
    public abstract record DomainEvent(Guid Id) : ICommonEvent;
}
