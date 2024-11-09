using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Helpline.Common.Types;

namespace Helpline.Common.Models
{
    public class Customer : BaseModel
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
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

        public ICollection<CustomerVehicle>? CustomerVehicles { get; set; }
        public ICollection<ServiceCase>? ServiceCases { get; set; }

        public Customer()
        {
            UserId = Guid.NewGuid().ToString();
        }
    }
}
