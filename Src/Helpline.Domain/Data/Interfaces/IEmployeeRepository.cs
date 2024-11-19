using Helpline.DataAccess.Models.Entities;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee, int>
    {
        Task<Employee?> GetEmployeeByUserIdAsync(string userId, CancellationToken cancellationToken);
    }
}
