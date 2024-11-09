using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Common.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        public string Address1 { get; private set; } = string.Empty;
        public string? Address2 { get; private set; }

        public string? City { get; private set; }
        public string? State { get; private set; }
        [Required]
        public string PostalCode { get; private set; } = string.Empty;
        public string? County { get; private set; }
        public string? Country { get; private set; }

        [ForeignKey("DealershipId")]
        public int? DealershipId { get; private set; }
        public Dealership? Dealership { get; set; }

        public ICollection<ApplicationUser>? Users { get; set; }
    }
}
