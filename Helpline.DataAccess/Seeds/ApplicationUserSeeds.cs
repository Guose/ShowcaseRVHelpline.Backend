using Helpline.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace Helpline.DataAccess.Seeds
{
    public class ApplicationUserSeeds
    {
        public static List<ApplicationUser> CreateUserSeeds(List<ApplicationUser> users, List<Address> addresses)
        {
            List<ApplicationUser> userSeeds = [];
            int index = 0;

            foreach (var user in users)
            {
                var newUser = new ApplicationUser
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    UserName = user.UserName,
                    Password = user.Password,
                    Role = user.Role,
                    Permssions = user.Permssions,
                    AddressId = user.AddressId,
                    Address = addresses[index],
                };

                newUser.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(newUser, user.Password!);

                userSeeds.Add(newUser);
                index++;
            }

            return userSeeds;
        }
    }
}
