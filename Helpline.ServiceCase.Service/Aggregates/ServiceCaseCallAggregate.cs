using Helpline.Domain.Events;
using Helpline.ServiceCaseService.Events;

namespace Helpline.ServiceCaseService.Aggregates
{
    public class ServiceCaseCallAggregate
    {
        private readonly List<IEvent> _events = new List<IEvent>();
        public IEnumerable<IEvent> Events => _events.AsReadOnly();
        public int CustomerId { get; private set; }
        public string IssueDescription { get; private set; }
        public DateTime CallStartTime { get; private set; }
        public DateTime? CallEndTime { get; private set; }
        public bool IsResolved { get; private set; }
        public int? KnowledgeBaseArticleId { get; private set; }
        public List<string> Tags { get; private set; }


        public ServiceCaseCallAggregate(int customerId, string issueDescription, List<string> tags)
        {
            CustomerId = customerId;
            IssueDescription = issueDescription;
            CallStartTime = DateTime.UtcNow;
            Tags = tags;
            IsResolved = false;

            // Raise an event
            var createdEvent = new ServiceCaseCallCreatedEvent(CustomerId, IssueDescription, CallStartTime, Tags);
            _events.Add(createdEvent);
        }

        public void ResolveCall(int knowledgeBaseArticleId)
        {
            IsResolved = true;
            KnowledgeBaseArticleId = knowledgeBaseArticleId;
            CallEndTime = DateTime.UtcNow;

            // Raise an event
            var resolvedEvent = new ServiceCaseCallResolvedEvent(KnowledgeBaseArticleId.Value, CallEndTime.Value);
            _events.Add(resolvedEvent);
        }

        public void EscalateToServiceCase()
        {
            // Raise an event
            var escalatedEvent = new ServiceCaseCallEscalatedEvent(CustomerId, IssueDescription, Tags);
            _events.Add(escalatedEvent);
        }
    }
}
