using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class ServiceCaseRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ServiceCase, HelplineContext, Guid>(context, logging), IServiceCaseRepository
    {
    }
}
