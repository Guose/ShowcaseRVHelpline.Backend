using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Shared.Models
{
    public class TechnicianService
    {
        [Key, Column(Order = 0)]
        public int? ServiceId { get; set; }

        [Key, Column(Order = 1)]
        public int? TechnicianId { get; set; }

        [InverseProperty("TechnicianServices")]
        public Technician? Technician { get; set; }

        [InverseProperty("TechnicianServices")]
        public ServiceClass? Service { get; set; }
    }
}
