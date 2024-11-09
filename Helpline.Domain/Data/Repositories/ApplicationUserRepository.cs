using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Helpline.Domain.Data.Repositories
{
    public class ApplicationUserRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ApplicationUser, HelplineContext, string>(context, logging), IApplicationUserRepository
    {
        public async Task<ApplicationUser?> GetUserByUsernameAsync(string username)
        {
            try
            {
                ApplicationUser? user = await Context.ApplicationUsers.SingleOrDefaultAsync(u => u.UserName == username);

                if (user == null)
                {
                    Logging.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(GetUserByUsernameAsync), this);
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(GetUserByUsernameAsync));
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
