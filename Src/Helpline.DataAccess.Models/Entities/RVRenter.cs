using Helpline.DataAccess.Models.Entities.Associations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.DataAccess.Models.Entities
{
    public class RVRenter : BaseModel
    {
        public string FullName { get; set; } = string.Empty;
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }
        public string RentalPortal { get; set; } = string.Empty;
        public bool IsRepeatRenter { get; set; } = false;

        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<VehicleRvRenter>? VehicleRvRenters { get; set; }
    }
}
