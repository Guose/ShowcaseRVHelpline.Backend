using Helpline.Common.Essentials;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Common.Models
{
    public abstract class BaseModel : IAuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Notes { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public IList<string>? Attachments { get; set; }
    }
}
