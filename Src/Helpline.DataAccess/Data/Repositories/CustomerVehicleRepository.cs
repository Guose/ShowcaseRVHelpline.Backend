using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.DataAccess.Data.Repositories
{
    public class CustomerVehicleRepository(HelplineContext context, ILogging logging) :
        BaseRepository<CustomerVehicle, HelplineContext, Guid>(context, logging), ICustomerVehicleRepository
    {
    }
}
