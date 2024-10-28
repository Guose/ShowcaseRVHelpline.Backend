using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Helpline.Common.Types;

namespace Helpline.Common.Models
{
    public class ServiceCase : BaseModel
    {
        [Key]
        [Required]
        public new Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        [Required]
        public ServiceCallSevType Sev { get; set; }


        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [ForeignKey("CustomerVehicleId")]
        public Guid CustomerVehicleId { get; set; }
        public CustomerVehicle? CustomerVehicle { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [ForeignKey("TechnicianId")]
        public int TechnicianId { get; set; }
        public Technician? Technician { get; set; }

        public ICollection<ServiceCaseCall>? ServiceCaseCalls { get; set; }
        public ICollection<ServiceCaseTag>? ServiceCaseTags { get; set; }
    }
}
