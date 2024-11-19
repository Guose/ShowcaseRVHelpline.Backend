namespace Helpline.DataAccess.Models.CoreElements
{
    public class AggregateRoot : Entity
    {
        private readonly List<ICommonEvent> domainEvents = new();

        protected AggregateRoot(Guid guidId) : base(guidId) { }
        protected AggregateRoot(Guid guidId, int intId) : base(guidId, intId) { }

        protected AggregateRoot() { }

        public IReadOnlyCollection<ICommonEvent> GetDomainEvents() => domainEvents.ToList();

        public void ClearDomainEvents() => domainEvents.Clear();

        protected void RaiseDomainEvent(ICommonEvent domainEvent) =>
            domainEvents.Add(domainEvent);
    }
}
