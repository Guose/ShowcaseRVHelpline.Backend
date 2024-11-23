using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Domain.Models.Entities
{
    public class RVService : BaseModel
    {
        [Required]
        public string Service { get; set; } = string.Empty;

        [Required]
        public string ServiceMethod { get; set; } = string.Empty;

        [Required]
        public string ServiceCode { get; set; } = string.Empty;

        [Required]
        public string Frequency { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [Precision(10, 2)]
        public decimal RetailPrice { get; set; }

        [Required]
        public string UOM { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        [Precision(5, 1)]
        public decimal CostPercent { get; set; }

        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        [Precision(5, 1)]
        public decimal GrossProfitPercent { get; set; }
    }
}
