using Helpline.Contracts.v1.Responses;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.ApplicationUsers.Queries
{
    public sealed record UserByIdQuery(Guid UserId) : IQuery<UserResponse>;
}
