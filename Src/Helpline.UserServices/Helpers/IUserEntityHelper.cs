using Helpline.DataAccess.Models.Types;
using Helpline.Domain.Data;

namespace Helpline.UserServices.Helpers
{
    public interface IUserEntityHelper
    {
        Task<object?> GetUserEntityByUserIdAsync(RoleType role, string userId, IUnitOfWork unitOfWork, CancellationToken cancellationToken);
        Task<bool> HandleUserEntityAsync(object entity, IUnitOfWork unitOfWork, string process, CancellationToken cancellationToken);
    }
}
