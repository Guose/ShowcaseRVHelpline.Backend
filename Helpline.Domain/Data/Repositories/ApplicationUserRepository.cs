using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Helpline.Domain.Data.Repositories
{
    public class ApplicationUserRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ApplicationUser, HelplineContext>(context, logging), IApplicationUserRepository
    {
        public Task<bool> ExecuteUpdateAsync(ApplicationUser applicationUser)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(string id)
        {
            try
            {
                ApplicationUser? user = await Context.ApplicationUsers.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    Logging.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(GetUserByIdAsync), this);
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(GetUserByIdAsync));
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<ApplicationUser?> ValidateUsernameAsync(string username)
        {
            try
            {
                ApplicationUser? user = await Context.ApplicationUsers.AsNoTracking().SingleOrDefaultAsync(u => u.UserName == username);

                if (user == null)
                {
                    Logging.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(ValidateUsernameAsync), this);
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ValidateUsernameAsync));
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
