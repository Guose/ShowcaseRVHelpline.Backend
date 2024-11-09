using Helpline.Common.Shared;
using MediatR;

namespace Helpline.Domain.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
