using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class CustomerRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Customer, HelplineContext, int>(context, logging), ICustomerRepository
    {
    }
}
