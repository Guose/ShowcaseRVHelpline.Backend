namespace Helpline.Domain.Events
{
    public sealed record CustomerRegisteredDomainEvent(Guid UserId, int CustomerId) : DomainEvent(UserId);
}
