using Helpline.Common.Models;

namespace Helpline.Domain.Data.Interfaces
{
    public interface IAuditLogRepository : IBaseRepository<AuditLog, int>
    {
    }
}
