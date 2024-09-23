using Helpline.Shared.Models;
using Helpline.Shared.Types;

namespace Helpline.DataAccess.Seeds
{
    public class HelplineSeedResolver : IHelplineSeedResolver
    {
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
            List<ApplicationUser> users = new List<ApplicationUser>();

            var user1 = ApplicationUserSeeds.CreateUserSeeds("Justin", "Elder", "4259234362", "justin@showcasemi.com", "guose", "5p3ctrum", RoleType.Admin, PermissionType.Admin);
            var user2 = ApplicationUserSeeds.CreateUserSeeds("John", "Elder", "4253302032", "john@showcasemi.com", "JohnE", "Admin", RoleType.Employee, PermissionType.Admin);
            var user3 = ApplicationUserSeeds.CreateUserSeeds("Keith", "McPherson", "3606319123", "keith.rvtech@gmail.com", "KeithM", "3422nesunset", RoleType.Technician, PermissionType.Limited);
            var user4 = ApplicationUserSeeds.CreateUserSeeds("Eric", "Shaw", "4253087638", "eric@showcaservhub.com", "EricS", "Admin", RoleType.Customer, PermissionType.Limited);
            var user5 = ApplicationUserSeeds.CreateUserSeeds("Jacob", "Skys", "4253068730", "jacob@skyautorepair.com", "Jacob_Skys", "password", RoleType.Dealership, PermissionType.Limited);

            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            users.Add(user4);
            users.Add(user5);

            return users;
        }
    }
}
