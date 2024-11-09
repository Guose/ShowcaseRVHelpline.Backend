﻿using Helpline.Common.Models;
using Helpline.Common.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Helpline.UserServices.DTOs.Requests
{
    public class CustomerRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public SubscriptionType SubscriptionType { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public bool SubscriptionStatus { get; set; }
        public UserRequest User { get; set; } = new();
    }
}
