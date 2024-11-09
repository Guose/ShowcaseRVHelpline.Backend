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
        public async Task<bool> ExecuteUpdateAsync(ApplicationUser user)
        {
            try
            {
                var result = await Context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

                if (result == null)
                    return false;

                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.Email = user.Email;
                result.PasswordHash = user.PasswordHash;
                result.PhoneNumber = user.PhoneNumber;
                result.UserName = user.UserName;
                result.Role = user.Role;
                result.Permssions = user.Permssions;
                result.IsRemembered = user.IsRemembered;
                result.AddressId = user.AddressId;

                Context.Users.Update(result);
                await SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ExecuteUpdateAsync));
                throw new ArgumentException(ex.Message);
            }
        }

        public override async Task<IEnumerable<ApplicationUser>> GetAllEntitiesAsync()
        {
            try
            {
                return await Context.Users
                    .Where(u => u.IsActive == true)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.FirstName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(GetAllEntitiesAsync));
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
