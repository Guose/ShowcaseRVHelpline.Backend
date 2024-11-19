using Helpline.Contracts.v1.Types;
using Helpline.Domain.Data;

namespace Helpline.UserServices.Helpers.UserEntityHelper
{
    public interface IUserEntityHelper
    {
        Task<object?> GetUserEntityByUserIdAsync(RoleType role, string userId, IUnitOfWork unitOfWork, CancellationToken cancellationToken);
        Task<bool> HandleUserEntityAsync(object entity, IUnitOfWork unitOfWork, string process, CancellationToken cancellationToken);
    }
}
