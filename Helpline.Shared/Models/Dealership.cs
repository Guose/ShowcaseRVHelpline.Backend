using System.ComponentModel.DataAnnotations;

namespace Helpline.Shared.Models
{
    public class Dealership : BaseModel
    {
        [Required]
        public string DealershipName { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        public string? WebPage { get; set; }

        public ICollection<DealershipContact>? DealershipContacts { get; set; }
    }
}
