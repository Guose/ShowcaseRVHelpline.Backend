using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;

namespace Helpline.DataAccess.Data.Repositories
{
    public class RVRentalRepository(HelplineContext context, ILogging logging) :
        BaseRepository<RVRental, HelplineContext, Guid>(context, logging), IRVRentalRepository
    {
    }
}
