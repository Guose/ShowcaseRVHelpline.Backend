using Helpline.Domain.Events;

namespace Helpline.ServiceCaseService.Events
{
    public class ServiceCaseCallEscalatedEvent : IEvent
    {
        public string IssueDescription { get; set; }
        public int CustomerId { get; set; }
        public List<string> TagNames { get; set; }

        public ServiceCaseCallEscalatedEvent(int customerId, string issueDescription, List<string> tagNames)
        {
            CustomerId = customerId;
            IssueDescription = issueDescription;
            TagNames = tagNames;
        }
    }
}
