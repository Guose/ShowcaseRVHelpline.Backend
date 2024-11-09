using Helpline.Common.Models;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IDealershipContactRepository : IBaseRepository<DealershipContact, int>
    {
        Task<DealershipContact?> GetDealershipContactByUserIdAsync(string userId);
    }
}
