using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;

namespace Helpline.DataAccess.Data.Repositories
{
    public class CustomerVehicleRepository(HelplineContext context, ILogging logging) :
        BaseRepository<CustomerVehicle, HelplineContext, Guid>(context, logging), ICustomerVehicleRepository
    {
    }
}
