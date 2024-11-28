using Helpline.DataAccess.Context;
using Helpline.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Helpline.DataAccess.Tests
{
    public class DatabaseFixture : IDisposable
    {
        public HelplineContext Context { get; }

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<HelplineContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique database
                .Options;

            Context = new HelplineContext(options);
            SeedData(Context);
        }

        private static void SeedData(HelplineContext context)
        {
            var users = new List<ApplicationUser>
        {
            new ApplicationUser
            {
                Id = "57A57CA5-5430-403B-B0A5-23FD4E710749",
                Email = "user1@test.com",
                UserName = "user1",
                PasswordHash = "password1"
            },
            new ApplicationUser
            {
                Id = "A6E6AD91-1BC1-4A1F-8189-522F7742D81F",
                Email = "user2@test.com",
                UserName = "user2",
                PasswordHash = "password2"
            }
        };

            context.AddRange(users);
            context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }

}
