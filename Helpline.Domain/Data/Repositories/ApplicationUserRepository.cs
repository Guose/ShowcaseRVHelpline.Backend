using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.Common.Shared;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Helpline.Domain.Data.Repositories
{
    public class ApplicationUserRepository(HelplineContext context, ILogging logging, UserManager<ApplicationUser> userManager) :
        BaseRepository<ApplicationUser, HelplineContext, string>(context, logging), IApplicationUserRepository
    {

        public async Task<ApplicationUser?> GetUserByUsernameAsync(string username)
        {
            try
            {
                ApplicationUser? user = await Context.Users.SingleOrDefaultAsync(u => u.UserName == username);

                Result<ApplicationUser> response = await userManager.FindByNameAsync(username);

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

        public async Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default) =>
            !await Context.Users.AnyAsync(u => u.Email == email.Value, cancellationToken);

        public async Task<bool> IsUserNameUniqueAsync(UserName userName, CancellationToken cancellationToken) =>
            !await Context.Users.AnyAsync(u => u.UserName == userName.Value, cancellationToken);

        public async Task<ApplicationUser?> GetByIdWithNoTrackingToUpdateUserProfileAsync(Guid userId, CancellationToken cancellationToken)
        {
            var user = await Context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId.ToString(), cancellationToken: cancellationToken);

            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}
