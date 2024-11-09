namespace Helpline.Domain.Events.Interfaces
{
    public interface IEventHandler<TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, CancellationToken cancellationToken);
    }
}
