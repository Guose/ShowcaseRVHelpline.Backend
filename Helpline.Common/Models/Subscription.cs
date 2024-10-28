using System.ComponentModel.DataAnnotations;
using Helpline.Common.Types;
using Microsoft.EntityFrameworkCore;

namespace Helpline.Common.Models
{
    public class Subscription : BaseModel
    {
        [Key]
        [Required]
        public new Guid Id { get; set; }

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
