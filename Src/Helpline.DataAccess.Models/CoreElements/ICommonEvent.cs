using MediatR;

namespace Helpline.DataAccess.Models.CoreElements
{
    public interface ICommonEvent : INotification
    {
        public Guid Id { get; init; }
    }
}
