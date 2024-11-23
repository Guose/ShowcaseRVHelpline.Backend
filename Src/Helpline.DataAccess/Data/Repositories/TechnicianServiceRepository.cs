using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities.Associations;

namespace Helpline.DataAccess.Data.Repositories
{
    public class TechnicianServiceRepository(HelplineContext context, ILogging logging) :
        BaseRepository<TechnicianService, HelplineContext, int>(context, logging), ITechnicianServiceRepository
    {
    }
}
