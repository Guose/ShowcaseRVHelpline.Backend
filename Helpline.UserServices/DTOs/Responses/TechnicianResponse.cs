namespace Helpline.UserServices.DTOs.Responses
{
    public class TechnicianResponse : UserResponse
    {
        public string? Company { get; set; }
        public UserResponse? User { get; set; }
    }
}
