using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class RVRentalRepository(HelplineContext context, ILogging logging) :
        BaseRepository<RVRental, HelplineContext, Guid>(context, logging), IRVRentalRepository
    {
    }
}
