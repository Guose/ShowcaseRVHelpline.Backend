using Helpline.Common.Models;

namespace Helpline.Domain.Data.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer, int>
    {
        Task<Customer?> GetCustomerByUserIdAsync(string userId);
    }
}
