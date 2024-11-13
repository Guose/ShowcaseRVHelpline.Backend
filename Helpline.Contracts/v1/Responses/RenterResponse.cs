namespace Helpline.Contracts.v1.Responses
{
    /// <summary>
    /// User profile that is returned from data access layer (DB)
    /// </summary>
    public class RenterResponse : UserResponse
    {
        public string RentalPortal { get; set; } = string.Empty;
        public bool IsRepeatRenter { get; set; }
        public UserResponse? User { get; set; }
    }
}
