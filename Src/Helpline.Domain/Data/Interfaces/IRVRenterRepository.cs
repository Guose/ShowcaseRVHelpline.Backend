using Helpline.DataAccess.Models.Entities;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IRVRenterRepository : IBaseRepository<RVRenter, int>
    {
        Task<RVRenter> GetRenterByUserIdAsync(string userId, CancellationToken cancellationToken);
    }
}
