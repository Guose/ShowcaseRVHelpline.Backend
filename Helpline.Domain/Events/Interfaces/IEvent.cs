namespace Helpline.Domain.Events.Interfaces
{
    public interface IEvent
    {
        Guid EventId { get; }
        string EventName { get; }
        DateTime CreatedOn { get; }
    }
}
