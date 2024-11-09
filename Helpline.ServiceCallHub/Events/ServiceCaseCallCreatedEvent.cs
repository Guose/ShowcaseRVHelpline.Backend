namespace Helpline.ServiceCallHub.Events
{
    public class ServiceCaseCallCreatedEvent
    {
        public int CustomerId { get; set; }
        public DateTime CallStartTime { get; set; }
        public List<string>? TagNames { get; set; }
        public string? IssueDescription { get; private set; }

        public Guid EventId => throw new NotImplementedException();

        public string EventName => throw new NotImplementedException();

        public DateTime CreatedOn => throw new NotImplementedException();

        public ServiceCaseCallCreatedEvent()
        {
            
        }

        public ServiceCaseCallCreatedEvent(int customerId, string issueDescription, DateTime callStartTime, List<string> tagNames)
        {
            CustomerId = customerId;
            IssueDescription = issueDescription;
            CallStartTime = callStartTime;
            TagNames = tagNames;
        }
    }
}
