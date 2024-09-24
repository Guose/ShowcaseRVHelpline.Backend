using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Shared.Models
{
    public class RVRenter : BaseModel
    {
        public bool IsRepeatRenter { get; set; } = false;

        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<VehicleRvRenter>? VehicleRvRenters { get; set; }
    }
}
