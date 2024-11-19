using Helpline.DataAccess.Models.CoreElements;
using MediatR;

namespace Helpline.Domain.Messaging
{
    public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
        where TEvent : ICommonEvent
    {
    }
}
