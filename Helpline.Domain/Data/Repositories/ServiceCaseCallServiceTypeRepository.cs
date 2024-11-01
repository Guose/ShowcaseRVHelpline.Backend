using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class ServiceCaseCallServiceTypeRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ServiceCaseCallServiceType, HelplineContext>(context, logging), IServiceCaseCallServiceTypeRepository
    {
    }
}
