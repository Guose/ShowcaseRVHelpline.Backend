using Helpline.Common.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Common.Models
{
    public class Customer : BaseModel
    {
        internal Customer(string userId)
        {
            UserId = userId;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public SubscriptionType SubscriptionType { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public bool SubscriptionStatus { get; set; }


        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }

        [ForeignKey("SubscriptionId")]
        public Guid SubscriptionId { get; set; }
        public Subscription? Subscription { get; set; }

        public ICollection<CustomerVehicle> CustomerVehicles { get; set; } = [];
        public ICollection<ServiceCase> ServiceCases { get; set; } = [];
    }
}
