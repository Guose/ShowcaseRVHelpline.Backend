using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Helpline.Shared.Types;

namespace Helpline.Shared.Models
{
    public class Subscription : BaseModel
    {
        [Required]
        public SubscriptionType SubscriptionType { get; set; }
        public string? Term { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        public ICollection<Customer>? Customers { get; set; }

    }
}
