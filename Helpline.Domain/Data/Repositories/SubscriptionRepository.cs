using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class SubscriptionRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Subscription, HelplineContext>(context, logging), ISubscriptionRepository
    {
    }
}
