using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class TechnicianRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Technician, HelplineContext, int>(context, logging), ITechnicianRepository
    {
    }
}
