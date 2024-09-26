using System.ComponentModel.DataAnnotations;

namespace Helpline.Shared.Models
{
    public class RVService : BaseModel
    {
        [Required] public string Service { get; set; } = string.Empty;
        [Required] public string ServiceMethod { get; set; } = string.Empty;
        [Required] public string ServiceCode { get; set; } = string.Empty;
        [Required] public string Frequency { get; set; } = string.Empty;
        public double RetailPrice { get; set; }
        [Required] public string UOM { get; set; } = string.Empty;
        public double CostPercent { get; set; }
        public double GrossProfitPercent { get; set; }
    }
}
