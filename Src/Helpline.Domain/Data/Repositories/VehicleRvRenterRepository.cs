using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities.Associations;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class VehicleRvRenterRepository(HelplineContext context, ILogging logging) :
        BaseRepository<VehicleRvRenter, HelplineContext, int>(context, logging), IVehicleRvRenterRepository
    {
    }
}
