using Helpline.Domain.Models.Entities;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address, int>
    {
        Task<bool> UpdateUsersAddressAsync(string userId, Address address);
    }
}
