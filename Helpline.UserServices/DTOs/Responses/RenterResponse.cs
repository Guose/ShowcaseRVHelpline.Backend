namespace Helpline.UserServices.DTOs.Responses
{
    public class RenterResponse : UserResponse
    {
        public string RentalPortal { get; set; } = string.Empty;
        public bool IsRepeatRenter { get; set; }
        public UserResponse? User { get; set; }
    }
}
