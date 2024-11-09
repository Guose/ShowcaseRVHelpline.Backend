namespace Helpline.ServiceCallHub.Events
{
    public class ServiceCaseCallEscalatedEvent
    {
        public string IssueDescription { get; set; }
        public int CustomerId { get; set; }
        public List<string> TagNames { get; set; }

        public Guid EventId => throw new NotImplementedException();

        public string EventName => throw new NotImplementedException();

        public DateTime CreatedOn => throw new NotImplementedException();

        public ServiceCaseCallEscalatedEvent(int customerId, string issueDescription, List<string> tagNames)
        {
            CustomerId = customerId;
            IssueDescription = issueDescription;
            TagNames = tagNames;
        }
    }
}
