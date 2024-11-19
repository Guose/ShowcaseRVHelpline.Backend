using Helpline.Common.Essentials;
using MediatR;

namespace Helpline.Domain.Messaging
{
    public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
        where TEvent : ICommonEvent
    {
    }
}
