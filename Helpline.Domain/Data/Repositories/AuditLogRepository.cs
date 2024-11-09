using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class AuditLogRepository(HelplineContext context, ILogging logging) :
        BaseRepository<AuditLog, HelplineContext, int>(context, logging), IAuditLogRepository
    {
    }
}
