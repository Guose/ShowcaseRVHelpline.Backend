﻿using Helpline.Domain.Models.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Domain.Models.Entities
{
    public class Customer : BaseModel
    {
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public SubscriptionType SubscriptionType { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public bool SubscriptionStatus { get; set; }


        [ForeignKey("UserId")]
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }

        [ForeignKey("SubscriptionId")]
        public Guid SubscriptionId { get; set; }
        public Subscription? Subscription { get; set; }

        public ICollection<CustomerVehicle> CustomerVehicles { get; set; } = [];
        public ICollection<ServiceCase> ServiceCases { get; set; } = [];
    }
}
