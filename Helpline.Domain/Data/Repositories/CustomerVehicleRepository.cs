using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class CustomerVehicleRepository(HelplineContext context, ILogging logging) :
        BaseRepository<CustomerVehicle, HelplineContext>(context, logging), ICustomerVehicleRepository
    {
    }
}
