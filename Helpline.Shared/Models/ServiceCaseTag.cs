using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Shared.Models
{
    public class ServiceCaseTag
    {
        [Key, Column(Order = 0)]
        public int? ServiceCaseId { get; set; }

        [Key, Column(Order = 1)]
        public int? TagId { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;

        [InverseProperty("ServiceCaseTags")]
        public Tag? Tag { get; set; }

        [InverseProperty("ServiceCaseTags")]
        public ServiceCase? ServiceCase { get; set; }
    }
}
