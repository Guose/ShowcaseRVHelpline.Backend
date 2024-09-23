using System.ComponentModel.DataAnnotations.Schema;
using Helpline.Shared.Types;

namespace Helpline.Shared.Models
{
    public class Technician : BaseModel
    {
        public string? Company { get; set; }
        public string? ReferralCode { get; set; }
        public bool IsW9OnFile { get; set; } = false;
        public string? Website { get; set; }

        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<ServiceType>? Services { get; set; }
        public ICollection<ServiceCase>? ServiceCases { get; set; }
    }
}
