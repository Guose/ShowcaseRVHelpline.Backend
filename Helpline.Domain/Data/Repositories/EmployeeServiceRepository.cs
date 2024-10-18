using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class EmployeeServiceRepository(HelplineContext context, ILogging logging) :
        GenericRepository<EmployeeService, HelplineContext>(context, logging), IEmployeeServiceRepository
    {
    }
}
