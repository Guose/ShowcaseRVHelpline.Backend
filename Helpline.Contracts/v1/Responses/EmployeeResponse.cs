using Helpline.Common.Models;

namespace Helpline.Contracts.v1.Responses
{
    /// <summary>
    /// User profile that is returned from data access layer (DB)
    /// </summary>
    public class EmployeeResponse : UserResponse
    {
        private readonly List<ServiceCase> serviceCases = [];

        public string? Company { get; set; }
        public string? JobTitle { get; set; }
        public UserResponse? User { get; set; }

        public ICollection<ServiceCase> ServiceCases => serviceCases;
    }
}
