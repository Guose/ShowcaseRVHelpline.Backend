using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.DataAccess.Data.Repositories
{
    public class RVReturnRepository(HelplineContext context, ILogging logging) :
        BaseRepository<RVReturn, HelplineContext, int>(context, logging), IRVReturnRepository
    {
    }
}
