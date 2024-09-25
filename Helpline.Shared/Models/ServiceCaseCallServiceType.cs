using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Shared.Models
{
    public class ServiceCaseCallServiceType
    {
        [Key, Column(Order = 0)]
        public int? ServiceCaseCallId { get; set; }

        [Key, Column(Order = 1)]
        public int? ServiceTypeId { get; set; }

        [InverseProperty("ServiceCaseCallServiceTypes")]
        public ServiceCaseCall? ServiceCaseCall { get; set; }

        [InverseProperty("ServiceCaseCallServiceTypes")]
        public RVService? ServiceType { get; set; }
    }
}
