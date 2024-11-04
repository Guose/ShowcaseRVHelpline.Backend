using Helpline.Common.Exceptions;
using Helpline.Common.Models;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser, string>
    {
        Task<ApplicationUser?> ValidateUsernameAsync(string username);
        Task<OperationResult> CreateNewUserEntityAsync<T>(ApplicationUser user, T entity) where T : class;
    }
}
