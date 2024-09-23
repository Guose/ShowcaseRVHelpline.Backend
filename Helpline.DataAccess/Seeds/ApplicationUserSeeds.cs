using Helpline.Shared.Models;
using Helpline.Shared.Types;
using Microsoft.AspNetCore.Identity;

namespace Helpline.DataAccess.Seeds
{
    public class ApplicationUserSeeds
    {
        public static ApplicationUser CreateUserSeeds(
            string firstname,
            string lastname,
            string phoneNumber,
            string email,
            string userName,
            string password,
            RoleType roleType,
            PermissionType permissions)
        {
            var user = new ApplicationUser
            {
                Firstname = firstname,
                Lastname = lastname,
                PhoneNumber = phoneNumber,
                Email = email,
                UserName = userName,
                Role = roleType,
                Permssions = permissions,
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, password);

            return user;
        }
    }
}
