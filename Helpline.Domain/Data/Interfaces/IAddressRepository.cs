using Helpline.Common.Models;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address, int>
    {
        Task<bool> UpdateUserAddressAsync(string userId, Address address);
    }
}
