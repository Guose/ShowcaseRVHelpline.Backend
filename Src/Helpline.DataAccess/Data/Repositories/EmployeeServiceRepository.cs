using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities.Associations;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.DataAccess.Data.Repositories
{
    public class EmployeeServiceRepository(HelplineContext context, ILogging logging) :
        BaseRepository<EmployeeService, HelplineContext, int>(context, logging), IEmployeeServiceRepository
    {
    }
}
