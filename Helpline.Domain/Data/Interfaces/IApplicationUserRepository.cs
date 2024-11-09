using Helpline.Common.Models;
using Helpline.Domain.ValueObjects;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser, string>
    {
        Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken);
        Task<bool> IsUserNameUniqueAsync(UserName userName, CancellationToken cancellationToken);
        Task<ApplicationUser?> GetUserByUsernameAsync(string username);
    }
}
