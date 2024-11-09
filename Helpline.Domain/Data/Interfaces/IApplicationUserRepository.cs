using Helpline.Common.Models;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser, string>
    {
        Task<bool> ExecuteUpdateAsync(ApplicationUser applicationUser);
        Task<ApplicationUser?> ValidateUsernameAsync(string username);
    }
}
