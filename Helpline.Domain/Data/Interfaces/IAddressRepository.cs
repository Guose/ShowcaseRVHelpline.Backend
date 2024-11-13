using Helpline.Common.Models;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address, int>
    {
        Task<bool> UpdateUsersAddressAsync(string userId, Address address);
    }
}
