using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;

namespace Helpline.DataAccess.Data.Repositories
{
    public class ServiceCaseCallRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ServiceCaseCall, HelplineContext, int>(context, logging), IServiceCaseCallRepository
    {

    }
}
