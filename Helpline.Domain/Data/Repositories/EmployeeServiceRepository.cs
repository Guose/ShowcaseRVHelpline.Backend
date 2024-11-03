using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class EmployeeServiceRepository(HelplineContext context, ILogging logging) :
        BaseRepository<EmployeeService, HelplineContext, int>(context, logging), IEmployeeServiceRepository
    {
    }
}
