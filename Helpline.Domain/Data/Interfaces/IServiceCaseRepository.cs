using Helpline.Common.Models;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IServiceCaseRepository : IBaseRepository<ServiceCase>
    {
        Task<bool> UpdateEntityAsync(ServiceCase serviceCase);
        Task<ServiceCase?> GetServiceCaseByIdAsync(int id);
    }
}
