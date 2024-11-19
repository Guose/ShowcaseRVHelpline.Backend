using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities.Associations;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class TechnicianServiceRepository(HelplineContext context, ILogging logging) :
        BaseRepository<TechnicianService, HelplineContext, int>(context, logging), ITechnicianServiceRepository
    {
    }
}
