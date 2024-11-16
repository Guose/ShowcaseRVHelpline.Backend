using Helpline.Common.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Helpline.Contracts.v1.Requests
{
    public class CustomerRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public SubscriptionType SubscriptionType { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public bool SubscriptionStatus { get; set; }
        public bool IsActive { get; set; }
        public Guid UserId { get; set; }
        public Guid SubscriptionId { get; set; }
    }
}
