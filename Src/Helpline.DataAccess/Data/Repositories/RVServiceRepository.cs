using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.DataAccess.Data.Repositories
{
    public class RVServiceRepository(HelplineContext context, ILogging logging) :
        BaseRepository<RVService, HelplineContext, int>(context, logging), IRVServiceRepository
    {
    }
}
