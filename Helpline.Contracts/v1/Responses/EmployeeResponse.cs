namespace Helpline.Contracts.v1.Responses
{
    /// <summary>
    /// User profile that is returned from data access layer (DB)
    /// </summary>
    public class EmployeeResponse : UserResponse
    {
        public string? Company { get; set; }
        public string? JobTitle { get; set; }
        public UserResponse? User { get; set; }
    }
}
