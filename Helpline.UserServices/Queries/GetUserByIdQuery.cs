using Helpline.Domain.Messaging;
using Helpline.UserServices.DTOs.Responses;

namespace Helpline.UserServices.Queries
{
    public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;
}
