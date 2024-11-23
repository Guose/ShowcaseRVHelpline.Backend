using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;

namespace Helpline.DataAccess.Data.Repositories
{
    public class RVCheckoutRepository(HelplineContext context, ILogging logging) :
        BaseRepository<RVCheckout, HelplineContext, int>(context, logging), IRVCheckoutRepository
    {
    }
}
