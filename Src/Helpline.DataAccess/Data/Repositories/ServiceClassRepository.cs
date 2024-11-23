using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;

namespace Helpline.DataAccess.Data.Repositories
{
    public class ServiceClassRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ServiceClass, HelplineContext, int>(context, logging), IServiceClassRepository
    {
    }
}
