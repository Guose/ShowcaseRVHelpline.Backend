using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class RVCheckoutRepository(HelplineContext context, ILogging logging) :
        GenericRepository<RVCheckout, HelplineContext>(context, logging), IRVCheckoutRepository
    {
    }
}
