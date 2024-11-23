using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;

namespace Helpline.DataAccess.Data.Repositories
{
    public class RVRenterRepository(HelplineContext context, ILogging logging) :
        BaseRepository<RVRenter, HelplineContext, int>(context, logging), IRVRenterRepository
    {
        public Task<RVRenter> GetRenterByUserIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
