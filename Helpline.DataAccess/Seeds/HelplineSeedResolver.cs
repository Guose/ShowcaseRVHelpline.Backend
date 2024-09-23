using Helpline.Shared.Models;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Helpline.DataAccess.Seeds
{
    public class HelplineSeedResolver : IHelplineSeedResolver
    {
        private readonly IConfiguration configuration;

        public HelplineSeedResolver()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public List<Address> GetAddressSeeds()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomerSeeds()
        {
            throw new NotImplementedException();
        }

        public List<CustomerVehicle> GetCustomerVehicleSeeds()
        {
            throw new NotImplementedException();
        }

        public List<DealershipContact> GetDealershipContactSeeds()
        {
            throw new NotImplementedException();
        }

        public List<Dealership> GetDealershipSeeds()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployeeSeeds()
        {
            throw new NotImplementedException();
        }

        public List<KnowledgeBaseLibrary> GetKnowledgeBaseLibrarySeeds()
        {
            throw new NotImplementedException();
        }

        public List<RVPartsDepartment> GetRVPartsDepartmentSeeds()
        {
            throw new NotImplementedException();
        }

        public List<RVRental> GetRVRentalsSeeds()
        {
            throw new NotImplementedException();
        }

        public List<ServiceDetail> GetRVServicesSeeds()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<Technician> GetTechnicianSeeds()
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetUserSeeds()
        {
            string? jsonFilePath = configuration.GetSection("JsonDataSettings:UserDataFilePath").Value;
            string jsonData = File.ReadAllText(jsonFilePath!);

            List<ApplicationUser> users = JsonSerializer.Deserialize<List<ApplicationUser>>(jsonData)!;

            ApplicationUserSeeds.CreateUserSeeds(users);

            return users;
        }
    }
}
