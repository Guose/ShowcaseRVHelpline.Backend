using Helpline.Common.Models;
using Helpline.Domain.Events;

namespace Helpline.ServiceCaseService.Events
{
    public class ServiceCaseCallCreatedEvent : IEvent
    {
        public int CustomerId { get; set; }
        public DateTime CallStartTime { get; set; }
        public List<string>? TagNames { get; set; }
        public string IssueDescription { get; private set; }

        public ServiceCaseCallCreatedEvent(int customerId, string issueDescription, DateTime callStartTime, List<string> tagNames)
        {
            CustomerId = customerId;
            IssueDescription = issueDescription;
            CallStartTime = callStartTime;
            TagNames = tagNames;
        }
    }
}
