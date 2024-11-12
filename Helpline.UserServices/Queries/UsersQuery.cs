using Helpline.Domain.Messaging;
using Helpline.UserServices.DTOs.Responses;

namespace Helpline.UserServices.Queries
{
    public sealed record UsersQuery : IQuery<IEnumerable<UserResponse>>;
}
