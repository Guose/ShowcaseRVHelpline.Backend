using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
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
            await Context.Users.FirstOrDefaultAsync(u => u.UserName == username.Value, cancellationToken) ?? null;

        public async Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default) =>
            !await Context.Users.AnyAsync(u => u.Email == email.Value, cancellationToken);

        public async Task<bool> IsUserNameUniqueAsync(UserName userName, CancellationToken cancellationToken = default) =>
            !await Context.Users.AnyAsync(u => u.UserName == userName.Value, cancellationToken);

        public async Task<ApplicationUser?> GetByIdWithNoTrackingToUpdateUserProfileAsync(Guid userId,
            CancellationToken cancellationToken = default) =>
            await Context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId.ToString(), cancellationToken) ?? null;

        public override async Task<Result> UpdateEntityAsync(ApplicationUser updatedUser, CancellationToken cancellationToken = default)
        {
            var existingUser = await userManager.FindByIdAsync(updatedUser.Id);
            if (existingUser is null)
                return Result.Failure(new Error(
                        "Entity.Update",
                        "Entity Update Failed"));

            existingUser.UserName = existingUser.UserName;
            existingUser.Email = existingUser.Email;
            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.PhoneNumber = updatedUser.PhoneNumber;
            existingUser.SecondaryPhone = updatedUser.SecondaryPhone;
            existingUser.ConcurrencyStamp = Guid.NewGuid().ToString();

            var result = await userManager.UpdateAsync(updatedUser);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            return Result.Success();
        }
    }
}
