namespace Helpline.Contracts.v1.Responses
{
    /// <summary>
    /// User profile that is returned from data access layer (DB)
    /// </summary>
    public class TechnicianResponse
    {
        private readonly List<ServiceCaseResponse> serviceCases = [];

        public string? Company { get; set; }
        public UserResponse? User { get; set; }

        IReadOnlyCollection<ServiceCaseResponse> ServiceCases => serviceCases;
    }
}
