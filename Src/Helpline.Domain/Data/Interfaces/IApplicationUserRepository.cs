using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.ValueObjects;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser, string>
    {
        Task<ApplicationUser?> GetByIdWithNoTrackingToUpdateUserProfileAsync(Guid userId, CancellationToken cancellationToken);
        Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken);
        Task<bool> IsUserNameUniqueAsync(UserName userName, CancellationToken cancellationToken);
        Task<ApplicationUser?> GetUserByUsernameAsync(string username);
    }
}
