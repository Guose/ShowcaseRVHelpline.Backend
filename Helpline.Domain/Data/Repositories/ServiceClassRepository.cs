using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class ServiceClassRepository(HelplineContext context, ILogging logging) :
        GenericRepository<ServiceClass, HelplineContext>(context, logging), IServiceClassRepository
    {
    }
}
