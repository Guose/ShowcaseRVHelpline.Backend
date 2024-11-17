using Helpline.Common.Models.Associations;
using Helpline.Common.Types;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Common.Models
{
    public class ServiceClass : BaseModel
    {
        [Required]
        public ServiceType ServiceType { get; set; }

        public ICollection<EmployeeService>? EmployeeServices { get; set; }
        public ICollection<TechnicianService>? TechnicianServices { get; set; }
        public ICollection<ServiceCaseCallServiceClass>? ServiceCaseCallServiceClasses { get; set; }
    }
}
