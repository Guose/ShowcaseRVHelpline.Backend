using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;

namespace Helpline.DataAccess.Data.Repositories
{
    public class ServiceCaseRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ServiceCase, HelplineContext, Guid>(context, logging), IServiceCaseRepository
    {
    }
}
