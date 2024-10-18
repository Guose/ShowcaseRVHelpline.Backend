namespace Helpline.Domain.Events
{
    public interface IEvent
    {
        Guid EventId { get; }
        string EventName { get; }
        DateTime CreatedOn { get; }
    }
}
