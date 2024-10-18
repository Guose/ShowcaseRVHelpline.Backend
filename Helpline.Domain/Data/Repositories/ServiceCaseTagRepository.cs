using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class ServiceCaseTagRepository(HelplineContext context, ILogging logging) :
        GenericRepository<ServiceCaseTag, HelplineContext>(context, logging), IServiceCaseTagRepository
    {
    }
}
