using Helpline.DataAccess.Models.Entities.Associations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.DataAccess.Models.Entities
{
    public class Technician : BaseModel
    {
        public string? Company { get; set; }
        public string? ReferralCode { get; set; }
        public bool IsW9OnFile { get; set; }
        public string? Website { get; set; }

        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<TechnicianService>? TechnicianServices { get; set; }
        public ICollection<ServiceCase>? ServiceCases { get; set; }
    }
}
