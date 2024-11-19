using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.DataAccess.Data.Repositories
{
    public class ServiceCaseCallRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ServiceCaseCall, HelplineContext, int>(context, logging), IServiceCaseCallRepository
    {

    }
}
