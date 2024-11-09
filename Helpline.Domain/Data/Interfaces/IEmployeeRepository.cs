using Helpline.Common.Models;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee, int>
    {
        Task<Employee?> GetEmployeeByUserIdAsync(string  userId);
    }
}
