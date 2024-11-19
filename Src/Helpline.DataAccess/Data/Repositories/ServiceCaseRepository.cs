using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.DataAccess.Data.Repositories
{
    public class ServiceCaseRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ServiceCase, HelplineContext, Guid>(context, logging), IServiceCaseRepository
    {
    }
}
