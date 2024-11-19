using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class SubscriptionRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Subscription, HelplineContext, Guid>(context, logging), ISubscriptionRepository
    {
    }
}
