using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Helpline.Domain.Data.Repositories
{
    public class CustomerRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Customer, HelplineContext, int>(context, logging), ICustomerRepository
    {
        public async Task<Customer?> GetCustomerByUserIdAsync(string userId)
        {
            return await Context.Customers.SingleOrDefaultAsync(c => c.UserId == userId);
        }
    }
}
