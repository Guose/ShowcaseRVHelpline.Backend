using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;

namespace Helpline.DataAccess.Data.Repositories
{
    public class RVReturnRepository(HelplineContext context, ILogging logging) :
        BaseRepository<RVReturn, HelplineContext, int>(context, logging), IRVReturnRepository
    {
    }
}
