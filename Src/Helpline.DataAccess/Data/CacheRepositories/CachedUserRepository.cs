using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.ValueObjects;
using Microsoft.Extensions.Caching.Memory;

namespace Helpline.DataAccess.Data.CacheRepositories
{
    public class CachedUserRepository : BaseRepository<ApplicationUser, HelplineContext, string>, IApplicationUserRepository
    {
        private readonly IApplicationUserRepository decorated;
        private readonly IMemoryCache memoryCache;
        public CachedUserRepository(
            HelplineContext context,
            ILogging logging,
            IApplicationUserRepository decorated,
            IMemoryCache memoryCache) : base(context, logging)
        {
            this.decorated = decorated;
            this.memoryCache = memoryCache;
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

        public Task<ApplicationUser?> GetByIdWithNoTrackingToUpdateUserProfileAsync(Guid userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
