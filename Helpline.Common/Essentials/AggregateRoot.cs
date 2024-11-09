namespace Helpline.Common.Essentials
{
    public class AggregateRoot : Entity
    {
        private readonly List<ICommonEvent> domainEvents = new();

        protected AggregateRoot(Guid id) : base(id) { }

        protected AggregateRoot() { }

        public IReadOnlyCollection<ICommonEvent> GetDomainEventso() => domainEvents.ToList();

        public void ClearDomainEvents() => domainEvents.Clear();

        protected void RaiseDomainEvent(ICommonEvent domainEvent) =>
            domainEvents.Add(domainEvent);
    }
}
