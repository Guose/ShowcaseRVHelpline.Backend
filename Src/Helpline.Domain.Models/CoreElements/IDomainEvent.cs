using MediatR;

namespace Helpline.Domain.Models.CoreElements
{
    public interface IDomainEvent : INotification
    {
        public Guid Id { get; init; }
    }
}
