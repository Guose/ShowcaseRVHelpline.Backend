using Helpline.Common.Models;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<bool> ExecuteUpdateAsync(ApplicationUser applicationUser);
        Task<ApplicationUser?> GetUserByIdAsync(string id);
        Task<ApplicationUser?> ValidateUsernameAsync(string username);
    }
}
