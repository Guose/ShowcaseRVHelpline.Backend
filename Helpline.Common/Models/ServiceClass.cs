using Helpline.Common.Models.Associations;
using Helpline.Common.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Common.Models
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
