using Helpline.Domain.Shared;
using MediatR;

namespace Helpline.Domain.Messaging
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
