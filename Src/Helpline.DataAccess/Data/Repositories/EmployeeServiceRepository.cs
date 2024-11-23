using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities.Associations;

namespace Helpline.DataAccess.Data.Repositories
{
    public class EmployeeServiceRepository(HelplineContext context, ILogging logging) :
        BaseRepository<EmployeeService, HelplineContext, int>(context, logging), IEmployeeServiceRepository
    {
    }
}
