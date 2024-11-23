using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;

namespace Helpline.DataAccess.Data.Repositories
{
    public class RVServiceRepository(HelplineContext context, ILogging logging) :
        BaseRepository<RVService, HelplineContext, int>(context, logging), IRVServiceRepository
    {
    }
}
