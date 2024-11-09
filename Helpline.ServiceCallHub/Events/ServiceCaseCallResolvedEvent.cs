namespace Helpline.ServiceCallHub.Events
{
    public class ServiceCaseCallResolvedEvent
    {
        public int Id { get; set; }
        public DateTime CallEndTime { get; set; }

        public Guid EventId => throw new NotImplementedException();

        public string EventName => throw new NotImplementedException();

        public DateTime CreatedOn => throw new NotImplementedException();

        public ServiceCaseCallResolvedEvent(int id, DateTime callEndTime)
        {
            Id = id;
            CallEndTime = callEndTime;
        }
    }
}
