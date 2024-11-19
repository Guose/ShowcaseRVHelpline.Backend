using Helpline.Common.Essentials;
using Helpline.DataAccess.Models.Entities;
using Helpline.DataAccess.Models.Types;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Helpline.DataAccess.Seeds
{
    public class HelplineSeedResolver
    {
        private readonly IConfiguration? configuration;
        public string? JsonFilePath => configuration!.GetSection("AppSettings:JsonDataFilePath").Value;

        public HelplineSeedResolver()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettingsDataAccess.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public List<T> LoadJsonDataAsync<T>(string fileName)
        {
            string filePath = JsonFilePath + fileName;
            using var reader = new StreamReader(filePath);
            var json = reader.ReadToEnd();

            return JsonSerializer.Deserialize<List<T>>(json)!;
        }

        public List<T> UpdateCreatedOnData<T>(List<T> items) where T : IAuditableEntity
        {
            List<T> updatedItems = [];

            foreach (var item in items)
            {
                item.CreatedOn = DateTime.Now;
                updatedItems.Add(item);
            }

            return updatedItems;
        }

        public List<RVRental> UpdateStartAndEndDates(List<RVRental> rentals)
        {
            List<RVRental> rentalSeeds = [];
            DateTime start = new DateTime();

            foreach (var rental in rentals)
            {
                switch (rental.RentalStatus)
                {
                    case RentalStatusType.Booked:
                        start = DateTime.Now.AddMonths(3);
                        break;
                    case RentalStatusType.OnTrip:
                        start = DateTime.Now.AddDays(-10);
                        break;
                    case RentalStatusType.Completed:
                        start = DateTime.Now.AddMonths(-10);
                        break;
                    default:
                        break;
                }

                rental.CreatedOn = DateTime.Now;
                rental.RentalStart = start;
                rental.RentalEnd = start.AddDays(30);

                rentalSeeds.Add(rental);
            }

            return rentalSeeds;
        }

        public List<ServiceCase> ServiceUpdateData(List<ServiceCase> customers)
        {
            List<ServiceCase> custsomerSeeds = [];

            foreach (var item in customers)
            {

                item.DueDate = DateTime.Now.AddMonths(10);
                item.CreatedOn = DateTime.Now;

                custsomerSeeds.Add(item);
            }

            return custsomerSeeds;
        }

        public List<Customer> CustomerUpdateData(List<Customer> customers)
        {
            List<Customer> custsomerSeeds = [];
            int month = 0;
            int count = 1;

            foreach (var item in customers)
            {
                if (count <= 1)
                {
                    month = -6;
                    count++;
                }
                else
                    month = -4;

                item.SubscriptionStartDate = DateTime.Now.AddMonths(month);
                item.SubscriptionEndDate = item.SubscriptionStartDate.AddMonths(12);
                item.CreatedOn = DateTime.Now;

                custsomerSeeds.Add(item);
            }

            return custsomerSeeds;
        }

        public List<ApplicationUser> GetUserSeeds(List<ApplicationUser> users)
        {
            List<ApplicationUser> userSeeds = [];
            foreach (var user in users)
            {
                user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, user.Password!);
                userSeeds.Add(user);
            }

            return userSeeds;
        }

    }
}
