using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Helpline.Domain.Data.Repositories
{
    public class EmployeeRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Employee, HelplineContext, int>(context, logging), IEmployeeRepository
    {
        public async Task<Employee?> GetEmployeeByUserIdAsync(string userId)
        {
            return await Context.Employees.SingleOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
