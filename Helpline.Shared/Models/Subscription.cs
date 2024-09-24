using System.ComponentModel.DataAnnotations;
using Helpline.Shared.Types;
using Microsoft.EntityFrameworkCore;

namespace Helpline.Shared.Models
{
    public class Subscription : BaseModel
    {
        [Required]
        public SubscriptionType SubscriptionType { get; set; }
        public string? Term { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [Precision(10, 2)]
        public decimal Price { get; set; }

        public ICollection<Customer>? Customers { get; set; }

    }
}
