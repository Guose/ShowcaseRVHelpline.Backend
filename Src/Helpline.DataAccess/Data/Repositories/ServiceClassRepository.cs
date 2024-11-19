using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.DataAccess.Data.Repositories
{
    public class ServiceClassRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ServiceClass, HelplineContext, int>(context, logging), IServiceClassRepository
    {
    }
}
