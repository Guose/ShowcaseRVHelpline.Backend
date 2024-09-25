using Helpline.DataAccess.Seeds;
using Helpline.Shared.Models;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HelplineSeedResolver seedResolver = new HelplineSeedResolver();

            List<ApplicationUser> users = seedResolver.GetUserSeeds();

            foreach (ApplicationUser user in users)
            {
                Console.WriteLine(user.PasswordHash);
            }
        }
    }
}
