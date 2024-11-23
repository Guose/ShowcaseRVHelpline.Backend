using Helpline.Domain.Models.CoreElements;
using MediatR;

namespace Helpline.Services.Abstractions.Messaging
{
    public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
        where TEvent : IDomainEvent
    {
    }
}
