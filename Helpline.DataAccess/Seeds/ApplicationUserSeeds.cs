using Helpline.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace Helpline.DataAccess.Seeds
{
    public class ApplicationUserSeeds
    {
        public static List<ApplicationUser> CreateUserSeeds(List<ApplicationUser> users)
        {
            List<ApplicationUser> userSeeds = [];

            foreach (var user in users)
            {
                var newUser = new ApplicationUser
                {
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    UserName = user.UserName,
                    Role = user.Role,
                    Permssions = user.Permssions,
                };

                var passwordHasher = new PasswordHasher<ApplicationUser>();
                newUser.PasswordHash = passwordHasher.HashPassword(newUser, user.Password!);

                userSeeds.Add(newUser);
            }

            return userSeeds;
        }
    }
}
