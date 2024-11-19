using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class RVCheckoutRepository(HelplineContext context, ILogging logging) :
        BaseRepository<RVCheckout, HelplineContext, int>(context, logging), IRVCheckoutRepository
    {
    }
}
