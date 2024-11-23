using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Domain.Models.Entities.Associations
{
    public class ServiceCaseCallServiceClass
    {
        public int? ServiceCaseCallId { get; set; }
        public int? ServiceClassId { get; set; }

        [InverseProperty("ServiceCaseCallServiceClasses")]
        public ServiceCaseCall? ServiceCaseCall { get; set; }

        [InverseProperty("ServiceCaseCallServiceClasses")]
        public ServiceClass? ServiceClass { get; set; }
    }
}
