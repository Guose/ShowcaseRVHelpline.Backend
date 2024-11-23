using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Helpline.DataAccess.Data.Repositories
{
    public class DealershipContactRepository(HelplineContext context, ILogging logging) :
        BaseRepository<DealershipContact, HelplineContext, int>(context, logging), IDealershipContactRepository
    {
        public async Task<DealershipContact?> GetDealershipContactByUserIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await Context.DealershipContacts.SingleOrDefaultAsync(x => x.UserId == userId, cancellationToken);
        }
    }
}
