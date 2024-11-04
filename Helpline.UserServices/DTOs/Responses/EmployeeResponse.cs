namespace Helpline.UserServices.DTOs.Responses
{
    public class EmployeeResponse : UserResponse
    {
        public string? Company { get; set; }
        public string? JobTitle { get; set; }
        public UserResponse? User { get; set; }
    }
}
