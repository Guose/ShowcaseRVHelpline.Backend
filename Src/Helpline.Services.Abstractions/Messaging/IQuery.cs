using Helpline.Domain.Shared;
using MediatR;

namespace Helpline.Services.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
