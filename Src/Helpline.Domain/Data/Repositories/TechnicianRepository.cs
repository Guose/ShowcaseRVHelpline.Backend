using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Helpline.Domain.Data.Repositories
{
    public class TechnicianRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Technician, HelplineContext, int>(context, logging), ITechnicianRepository
    {
        public override async Task<IEnumerable<Technician>> GetAllEntitiesAsync(CancellationToken cancellationToken)
        {
            return await Context.Technicians
                .Include(u => u.User)
                    .ThenInclude(a => a!.Address)
                .ToListAsync();
        }

        public async Task<Technician?> GetTechnicianByUserIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await Context.Technicians
                .Include(u => u.User)
                    .ThenInclude(a => a!.Address)
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }
}
