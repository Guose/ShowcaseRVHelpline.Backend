using Helpline.Domain.Models.Entities;
using Helpline.Domain.ValueObjects;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser, string>
    {
        Task<ApplicationUser?> GetByIdWithNoTrackingToUpdateUserProfileAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default);
        Task<bool> IsUserNameUniqueAsync(UserName userName, CancellationToken cancellationToken = default);
        Task<ApplicationUser?> GetUserByUsernameAsync(UserName username, CancellationToken cancellationToken = default);
    }
}
