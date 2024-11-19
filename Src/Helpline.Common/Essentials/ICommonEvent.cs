using MediatR;

namespace Helpline.Common.Essentials
{
    public interface ICommonEvent : INotification
    {
        public Guid Id { get; init; }
    }
}
