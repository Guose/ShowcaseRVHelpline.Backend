using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class RVRenterRepository(HelplineContext context, ILogging logging) :
        BaseRepository<RVRenter, HelplineContext>(context, logging), IRVRenterRepository
    {
    }
}
