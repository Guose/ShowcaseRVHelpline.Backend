using Helpline.Domain.Models.Entities;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IDealershipContactRepository : IBaseRepository<DealershipContact, int>
    {
        Task<DealershipContact?> GetDealershipContactByUserIdAsync(string userId, CancellationToken cancellationToken);
    }
}
