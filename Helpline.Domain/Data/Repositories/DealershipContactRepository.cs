using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class DealershipContactRepository(HelplineContext context, ILogging logging) :
        BaseRepository<DealershipContact, HelplineContext, int>(context, logging), IDealershipContactRepository
    {
    }
}
