using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Helpline.DataAccess.Data.Repositories
{
    public class CustomerRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Customer, HelplineContext, int>(context, logging), ICustomerRepository
    {
        public async Task<Customer?> GetCustomerByUserIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await Context.Customers
                .Include(u => u.User)
                    .ThenInclude(a => a!.Address)
                .Include(v => v.CustomerVehicles)
                .Include(s => s.Subscription)
                .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);
        }
    }
}
