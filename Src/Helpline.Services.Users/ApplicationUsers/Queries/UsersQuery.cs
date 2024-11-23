using Helpline.Domain.Models.Entities;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.ApplicationUsers.Queries
{
    public sealed record UsersQuery : IQuery<IEnumerable<ApplicationUser>>;
}
