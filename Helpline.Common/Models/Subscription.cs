﻿using Helpline.Common.Types;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Common.Models
{
    public class Subscription : BaseModel
    {
        [Key]
        [Required]
        public new Guid Id { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public SubscriptionType SubscriptionType { get; set; }
        public string? Term { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [Precision(10, 2)]
        public decimal Price { get; set; }

        public ICollection<Customer>? Customers { get; set; }

    }
}
