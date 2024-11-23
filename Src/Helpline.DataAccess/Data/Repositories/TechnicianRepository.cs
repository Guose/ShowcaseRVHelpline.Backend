using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Helpline.DataAccess.Data.Repositories
{
    public class TechnicianRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Technician, HelplineContext, int>(context, logging), ITechnicianRepository
    {
        public override async Task<IEnumerable<Technician>> GetAllEntitiesAsync(CancellationToken cancellationToken)
        {
            return await Context.Technicians
                .Include(u => u.User)
                    .ThenInclude(a => a!.Address)
                .ToListAsync(cancellationToken);
        }

        public async Task<Technician?> GetTechnicianByUserIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await Context.Technicians
                .Include(u => u.User)
                    .ThenInclude(a => a!.Address)
                .FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);
        }
    }
}
