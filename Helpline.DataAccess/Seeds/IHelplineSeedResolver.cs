using Helpline.Shared.Models;

namespace Helpline.DataAccess.Seeds
{
    public interface IHelplineSeedResolver
    {
        List<Address> GetAddressSeeds();
        List<Customer> GetCustomerSeeds();
        List<CustomerVehicle> GetCustomerVehicleSeeds();
        List<Dealership> GetDealershipSeeds();
        List<DealershipContact> GetDealershipContactSeeds();
        List<Employee> GetEmployeeSeeds();
        List<KnowledgeBaseLibrary> GetKnowledgeBaseLibrarySeeds();
        List<RVRental> GetRVRentalsSeeds();
        List<ServiceDetail> GetServiceDetailSeeds();
        List<ServiceCase> GetServiceCaseSeeds();
        List<ServiceCaseCall> GetServiceCaseCallSeeds();
        List<Subscription> GetSubscriptionSeeds();
        List<Technician> GetTechnicianSeeds();
        List<ApplicationUser> GetUserSeeds();
    }
}
