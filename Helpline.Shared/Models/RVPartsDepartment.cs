using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Shared.Models
{
    public class RVPartsDepartment : BaseModel
    {
        public string? CompanyName { get; set; }
        public string? Webpage { get; set; }
    }
}
