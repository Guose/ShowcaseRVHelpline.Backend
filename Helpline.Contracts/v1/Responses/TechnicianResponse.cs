namespace Helpline.Contracts.v1.Responses
{
    /// <summary>
    /// User profile that is returned from data access layer (DB)
    /// </summary>
    public class TechnicianResponse : UserResponse
    {
        public string? Company { get; set; }
        public UserResponse? User { get; set; }
    }
}
