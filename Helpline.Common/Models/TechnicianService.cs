using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Common.Models
{
    public class TechnicianService
    {
        public int? ServiceId { get; set; }
        public int? TechnicianId { get; set; }

        [InverseProperty("TechnicianServices")]
        public Technician? Technician { get; set; }

        [InverseProperty("TechnicianServices")]
        public ServiceClass? Service { get; set; }
    }
}
