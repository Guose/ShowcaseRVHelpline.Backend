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
        public override async Task<IEnumerable<Employee>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Employees
                .Include(u => u.User)
                    .ThenInclude(a => a!.Address)
                .Include(sc => sc.ServiceCases!)
                    .ThenInclude(c => c.Customer)
                .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByUserIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await Context.Employees
                .Include(u => u.User)
                    .ThenInclude(a => a!.Address)
                .FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
