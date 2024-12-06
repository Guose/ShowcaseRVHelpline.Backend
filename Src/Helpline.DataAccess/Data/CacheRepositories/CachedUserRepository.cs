using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Helpline.DataAccess.Data.CacheRepositories
{
    public class CachedUserRepository : BaseRepository<ApplicationUser, HelplineContext, string>, IApplicationUserRepository
    {
        private readonly IApplicationUserRepository decorated;
        private readonly IMemoryCache memoryCache;
        private readonly UserManager<ApplicationUser> userManager;
        public CachedUserRepository(
            HelplineContext context,
            ILogging logging,
            IApplicationUserRepository decorated,
            IMemoryCache memoryCache,
            UserManager<ApplicationUser> userManager) : base(context, logging)
        {
            this.decorated = decorated;
            this.memoryCache = memoryCache;
            this.userManager = userManager;
        }

        public Task<ApplicationUser?> GetUserByUsernameAsync(UserName username, CancellationToken cancellationToken = default)
        {
            string key = $"user-{username}";

            return memoryCache.GetOrCreateAsync(key, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                return decorated.GetUserByUsernameAsync(username, cancellationToken);
            });
        }

        public Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken) =>
            decorated.IsEmailUniqueAsync(email, cancellationToken);

        public Task<bool> IsUserNameUniqueAsync(UserName userName, CancellationToken cancellationToken) =>
            decorated.IsUserNameUniqueAsync(userName, cancellationToken);

        public async Task<ApplicationUser?> GetByIdWithNoTrackingToUpdateUserProfileAsync(Guid userId,
            CancellationToken cancellationToken = default) =>
            await Context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId.ToString(), cancellationToken) ?? null;

        public override async Task<bool> UpdateEntityAsync(ApplicationUser updatedUser, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await userManager.FindByIdAsync(updatedUser.Id);
                if (user is null)
                    return false;

                user.ConcurrencyStamp = Guid.NewGuid().ToString();
                var result = await userManager.UpdateAsync(user);

                if (!result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

                Context.Users.Attach(user);
                Context.Entry(user).State = EntityState.Modified;

                Context.Users.Update(updatedUser);

                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is IdentityUser)
                    {
                        var databaseValues = entry.GetDatabaseValues();
                        if (databaseValues == null)
                        {
                            throw new Exception("The user was deleted by another process.");
                        }
                        else
                        {
                            entry.OriginalValues.SetValues(databaseValues);
                            throw new Exception("The user was updated by another process.");
                        }
                    }
                }
                throw;
            }
        }
    }
}
