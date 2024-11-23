namespace Helpline.Domain.Models.CoreElements
{
    public class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> domainEvents = [];

        protected AggregateRoot(Guid guidId) : base(guidId) { }
        protected AggregateRoot(Guid guidId, int intId) : base(guidId, intId) { }

        protected AggregateRoot() { }

        public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => [.. domainEvents];

        public void ClearDomainEvents() => domainEvents.Clear();

        protected void RaiseDomainEvent(IDomainEvent domainEvent) =>
            domainEvents.Add(domainEvent);
    }
}
