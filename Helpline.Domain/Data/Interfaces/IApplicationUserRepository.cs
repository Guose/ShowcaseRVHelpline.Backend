using Helpline.Common.Models;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser, string>
    {
        Task<ApplicationUser?> GetUserByUsernameAsync(string username);
    }
}
