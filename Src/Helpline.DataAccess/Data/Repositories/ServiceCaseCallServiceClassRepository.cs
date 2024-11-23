using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities.Associations;

namespace Helpline.DataAccess.Data.Repositories
{
    public class ServiceCaseCallServiceClassRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ServiceCaseCallServiceClass, HelplineContext, int>(context, logging), IServiceCaseCallServiceClassRepository
    {
    }
}
