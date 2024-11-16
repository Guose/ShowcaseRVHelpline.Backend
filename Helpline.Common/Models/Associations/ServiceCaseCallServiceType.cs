using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Common.Models.Associations
{
    public class ServiceCaseCallServiceType
    {
        public int? ServiceCaseCallId { get; set; }
        public int? ServiceTypeId { get; set; }

        [InverseProperty("ServiceCaseCallServiceTypes")]
        public ServiceCaseCall? ServiceCaseCall { get; set; }

        [InverseProperty("ServiceCaseCallServiceTypes")]
        public ServiceClass? ServiceType { get; set; }
    }
}
