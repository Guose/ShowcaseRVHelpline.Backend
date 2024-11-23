using Helpline.Domain.Models.Entities.Associations;
using Helpline.Domain.Models.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Domain.Models.Entities
{
    public class ServiceClass : BaseModel
    {
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public ServiceType ServiceType { get; set; }

        public ICollection<EmployeeService>? EmployeeServices { get; set; }
        public ICollection<TechnicianService>? TechnicianServices { get; set; }
        public ICollection<ServiceCaseCallServiceClass>? ServiceCaseCallServiceClasses { get; set; }
    }
}
