using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Shared.Models
{
    public class ServiceCaseTag
    {
        public int? ServiceCaseId { get; set; }
        public int? TagId { get; set; }

        [InverseProperty("ServiceCaseTags")]
        public Tag? Tag { get; set; }

        [InverseProperty("ServiceCaseTags")]
        public ServiceCase? ServiceCase { get; set; }
    }
}
