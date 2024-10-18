using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class RVServiceRepository(HelplineContext context, ILogging logging) :
        GenericRepository<RVService, HelplineContext>(context, logging), IRVServiceRepository
    {
    }
}
