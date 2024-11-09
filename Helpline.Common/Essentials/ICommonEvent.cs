using MediatR;

namespace Helpline.Common.Essentials
{
    public interface ICommonEvent : INotification
    {
        public Guid Id { get; init; }
        public string UserId { get; init; }
    }
}
