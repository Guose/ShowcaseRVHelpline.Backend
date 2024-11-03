using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class RVReturnRepository(HelplineContext context, ILogging logging) :
        BaseRepository<RVReturn, HelplineContext, int>(context, logging), IRVReturnRepository
    {
    }
}
