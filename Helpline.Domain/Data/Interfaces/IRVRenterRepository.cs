using Helpline.Common.Models;
using System.Runtime.CompilerServices;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IRVRenterRepository : IBaseRepository<RVRenter, int>
    {
        Task<RVRenter> GetRenterByUserIdAsync(string  userId);
    }
}
