using Helpline.Common.Models;

namespace Helpline.UserServices.DTOs.Requests
{
    public class TechnicianRequest
    {
        public string? Company { get; set; }
        public string? ReferralCode { get; set; }
        public bool IsW9OnFile { get; set; }
        public string? Website { get; set; }
        public UserRequest User { get; set; } = new();
    }
}
