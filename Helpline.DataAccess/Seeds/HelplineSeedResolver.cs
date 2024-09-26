using Helpline.Shared.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Helpline.DataAccess.Seeds
{
    public class HelplineSeedResolver : IHelplineSeedResolver
    {
        private readonly IConfiguration configuration;
        public string? JsonFilePath => configuration.GetSection("JsonDataSettings:UserDataFilePath").Value;

        public HelplineSeedResolver()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public List<Address> GetAddressSeeds()
        {
            return JsonSerializer.Deserialize<List<Address>>(JsonFilePath + "address.json")!;
        }

        public List<Customer> GetCustomerSeeds()
        {
            return JsonSerializer.Deserialize<List<Customer>>(JsonFilePath + "customer.json")!;
        }

        public List<CustomerVehicle> GetCustomerVehicleSeeds()
        {
            return JsonSerializer.Deserialize<List<CustomerVehicle>>(JsonFilePath + "customerVehicle.json")!;
        }

        public List<DealershipContact> GetDealershipContactSeeds()
        {
            throw new NotImplementedException();
        }

        public List<Dealership> GetDealershipSeeds()
        {
            return JsonSerializer.Deserialize<List<Dealership>>(JsonFilePath + "dealerships.json")!;
        }

        public List<Employee> GetEmployeeSeeds()
        {
            throw new NotImplementedException();
        }

        public List<KnowledgeBaseLibrary> GetKnowledgeBaseLibrarySeeds()
        {
            throw new NotImplementedException();
        }

        public List<RVRental> GetRVRentalsSeeds()
        {
            throw new NotImplementedException();
        }

        public List<RVService> GetServiceDetailSeeds()
        {
            return JsonSerializer.Deserialize<List<RVService>>(JsonFilePath + "serviceDetail.json")!;
        }

        public List<ServiceCaseCall> GetServiceCaseCallSeeds()
        {
            throw new NotImplementedException();
        }

        public List<ServiceCase> GetServiceCaseSeeds()
        {
            throw new NotImplementedException();
        }

        public List<Subscription> GetSubscriptionSeeds()
        {
            return JsonSerializer.Deserialize<List<Subscription>>(JsonFilePath + "subscription.json")!;
        }

        public List<Technician> GetTechnicianSeeds()
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetUserSeeds()
        {
            List<Address> addresses = GetAddressSeeds();
            string jsonData = File.ReadAllText(JsonFilePath + "user.json");

            List<ApplicationUser> users = JsonSerializer.Deserialize<List<ApplicationUser>>(jsonData)!;

            return ApplicationUserSeeds.CreateUserSeeds(users, addresses);
        }
    }
}
