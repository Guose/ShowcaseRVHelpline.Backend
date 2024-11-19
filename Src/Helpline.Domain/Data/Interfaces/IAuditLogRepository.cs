using Helpline.DataAccess.Models.Entities;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IAuditLogRepository : IBaseRepository<AuditLog, int>
    {
    }
}
