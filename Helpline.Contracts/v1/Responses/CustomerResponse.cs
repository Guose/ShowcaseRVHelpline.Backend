using Helpline.Common.Types;

namespace Helpline.Contracts.v1.Responses
{
    /// <summary>
    /// User profile that is returned from data access layer (DB)
    /// </summary>
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
