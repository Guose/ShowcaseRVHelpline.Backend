using Helpline.Domain.Models.Entities;

namespace Helpline.Domain.Data.Interfaces
{
    public interface ITechnicianRepository : IBaseRepository<Technician, int>
    {
        Task<Technician?> GetTechnicianByUserIdAsync(string userId, CancellationToken cancellationToken);
    }
}
