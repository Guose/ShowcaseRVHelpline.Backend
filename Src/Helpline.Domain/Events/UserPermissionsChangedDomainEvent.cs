namespace Helpline.Domain.Events
{
    public sealed record UserPermissionsChangedDomainEvent(Guid Id, Guid UserId) : DomainEvent(Id);
}
