using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Common.Models
{
    public class Dealership : BaseModel
    {
        [Required]
        public string DealershipName { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        public string? WebPage { get; set; }

        [ForeignKey("AddressId")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }

        public ICollection<DealershipContact>? DealershipContacts { get; set; }
    }
}
