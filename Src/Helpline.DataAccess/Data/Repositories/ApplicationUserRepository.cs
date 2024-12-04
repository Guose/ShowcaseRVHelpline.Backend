using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Helpline.DataAccess.Data.Repositories
{
    public class ApplicationUserRepository(HelplineContext context, ILogging logging, UserManager<ApplicationUser> userManager) :
        BaseRepository<ApplicationUser, HelplineContext, string>(context, logging), IApplicationUserRepository
    {
        public async Task<ApplicationUser?> GetUserByUsernameAsync(UserName username,
            CancellationToken cancellationToken = default) =>
            // await Context.Users.FirstOrDefaultAsync(u => u.UserName == username.Value, cancellationToken) ?? null;
            await userManager.FindByNameAsync(username.Value) ?? null;

        public async Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default) =>
            !await Context.Users.AnyAsync(u => u.Email == email.Value, cancellationToken);

        public async Task<bool> IsUserNameUniqueAsync(UserName userName, CancellationToken cancellationToken = default) =>
            !await Context.Users.AnyAsync(u => u.UserName == userName.Value, cancellationToken);

        public async Task<ApplicationUser?> GetByIdWithNoTrackingToUpdateUserProfileAsync(Guid userId,
            CancellationToken cancellationToken = default) =>
            await Context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId.ToString(), cancellationToken) ?? null;
    }
}
