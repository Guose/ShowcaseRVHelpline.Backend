using Helpline.Common.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Common.Models
{
    public class DealershipContact : BaseModel
    {
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public DepartmentType Department { get; set; }
        public string? Title { get; set; }
        public string? PromoCode { get; set; }

        [Required]
        [ForeignKey("DealershipId")]
        public int DealershipId { get; set; }
        [Required]
        public Dealership Dealership { get; set; } = new();

        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
