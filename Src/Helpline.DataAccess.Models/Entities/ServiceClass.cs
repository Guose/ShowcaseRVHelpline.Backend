using Helpline.DataAccess.Models.Entities.Associations;
using Helpline.DataAccess.Models.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Helpline.DataAccess.Models.Entities
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
