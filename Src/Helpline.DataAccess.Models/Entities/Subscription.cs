using Helpline.DataAccess.Models.Types;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Helpline.DataAccess.Models.Entities
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

        [JsonIgnore]
        public ICollection<Customer>? Customers { get; set; }

    }
}
