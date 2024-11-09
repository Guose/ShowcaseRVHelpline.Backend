using Helpline.Domain.Events.Interfaces;

namespace Helpline.Domain.Messaging
{
    public interface IMessageBus
    {
        Task PublishAsync<T>(T message) where T : class;
        Task SubscribeAsync<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent;
    }
}
