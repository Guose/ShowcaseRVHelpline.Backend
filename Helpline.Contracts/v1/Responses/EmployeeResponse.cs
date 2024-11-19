namespace Helpline.Contracts.v1.Responses
{
    /// <summary>
    /// User profile that is returned from data access layer (DB)
    /// </summary>
    public class EmployeeResponse
    {
        private readonly List<ServiceCaseResponse> serviceCases = [];

        public EmployeeResponse()
        {
            FullName = string.Empty;
            Company = string.Empty;
            JobTitle = string.Empty;
            User = new();
        }
        private EmployeeResponse(
            string fullName,
            string company,
            string jobTitle,
            UserResponse user,
            List<ServiceCaseResponse> serviceCases)
        {
            FullName = fullName;
            Company = company;
            JobTitle = jobTitle;
            User = user;
            this.serviceCases = serviceCases;
        }

        public string FullName { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public UserResponse User { get; set; }

        public IReadOnlyCollection<ServiceCaseResponse> ServiceCases => serviceCases;

        public static EmployeeResponse Create(
            string fullname,
            string company,
            string jobTitle,
            UserResponse user,
            List<ServiceCaseResponse> serviceCases)
        {
            return new EmployeeResponse(
                fullname,
                company,
                jobTitle,
                user,
                serviceCases);
        }
    }
}
