using Helpline.Common.Types;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Common.Models
{
    public class DealershipContact : BaseModel
    {
        public DepartmentType Department { get; set; }
        public string? Title { get; set; }
        public string? PromoCode { get; set; }

        [Required]
        [ForeignKey("DealershipId")]
        public int DealershipId { get; set; }
        [Required]
        public Dealership Dealership { get; set; } = new();

        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
