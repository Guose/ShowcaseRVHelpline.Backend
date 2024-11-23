using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;

namespace Helpline.DataAccess.Data.Repositories
{
    public class SubscriptionRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Subscription, HelplineContext, Guid>(context, logging), ISubscriptionRepository
    {
    }
}
