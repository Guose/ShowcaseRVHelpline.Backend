namespace Helpline.Domain.Events.Interfaces
{
    public interface IEventPublisher
    {
        Task PublishAsync<T>(T @event, CancellationToken cancellationToken) where T : class;
    }
}
