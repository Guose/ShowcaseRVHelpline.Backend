using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;

namespace Helpline.DataAccess.Data.Repositories
{
    public class AuditLogRepository(HelplineContext context, ILogging logging) :
        BaseRepository<AuditLog, HelplineContext, int>(context, logging), IAuditLogRepository
    {
    }
}
