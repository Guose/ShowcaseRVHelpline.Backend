namespace Helpline.Common.Constants
{
    public static class HelplineRoutes
    {
        // Controllers Base
        public const string BaseUri = "api/v1/";

        // UserServicesRoutes
        public const string UserControllerRoute = BaseUri + "UserServices";
        public const string GetUsersRoute = "Users";
        public const string UserRoute = "User";
        public const string UserRouteById = "User/{userId}";
        public const string UserRoutePermissionsById = "User/Access/{userId}";

        // EmployeeRoutes
        public const string EmployeeRoute = "Employee";
        public const string GetEmployeesRoute = "Employees";
        public const string EmployeeRouteById = "Employee/{userId}";

        // EmployeeRoutes
        public const string TechnicianRoute = "Technician";
        public const string GetTechniciansRoute = "Technicians";
        public const string TechnicianRouteById = "Technician/{userId}";

        // AddressRoutes
        public const string AddressesRoute = "Addresses";
        public const string AddressByIdRoute = "Address/{userId}";

        // CustomerRoutes
        public const string SubscriptionControllerRoute = BaseUri + "SubscriptionService";
        public const string CustomersRoute = "Customers";
        public const string CustomerByIdRoute = "Customer/{userId}";

        // ServiceCaseRoutes
        public const string ServiceCaseControllerRoute = BaseUri + "ServiceCase";
        public const string ServiceCasesRoute = "ServiceCases";
        public const string ServiceCaseByIdRoute = "ServiceCase/{userId}";
    }
}
