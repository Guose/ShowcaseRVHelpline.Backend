using Helpline.Common.Types;

namespace Helpline.UserServices.DTOs.Responses
{
    public class CustomerResponse
    {
        public SubscriptionType SubscriptionType { get; set; }
        public Guid SubscriptionId { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public bool SubscriptionStatus { get; set; }
        public UserResponse? User { get; set; }
    }
}
