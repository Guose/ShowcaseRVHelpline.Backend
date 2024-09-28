using Helpline.Shared.Types;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Shared.Models
{
    public class ServiceClass : BaseModel
    {
        [Required]
        public ServiceType ServiceType { get; set; }

        public ICollection<EmployeeService>? EmployeeServices { get; set; }
        public ICollection<TechnicianService>? TechnicianServices { get; set; }
        public ICollection<ServiceCaseCallServiceType>? ServiceCaseCallServiceTypes { get; set; }
    }
}
