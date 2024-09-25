using Helpline.Shared.Types;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Shared.Models
{
    public class RVService : BaseModel
    {
        [Required]
        public ServiceType Name { get; set; }

        public ICollection<ServiceCaseCallServiceType>? ServiceCaseCallServiceTypes { get; set; }
    }
}
