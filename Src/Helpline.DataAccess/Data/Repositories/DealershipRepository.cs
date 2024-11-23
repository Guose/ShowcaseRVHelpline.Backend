using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;

namespace Helpline.DataAccess.Data.Repositories
{
    public class DealershipRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Dealership, HelplineContext, int>(context, logging), IDealershipRepository
    {
    }
}
