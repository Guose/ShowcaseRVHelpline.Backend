using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Shared.Models
{
    public class KnowledgeBaseTag
    {
        [Key, Column(Order = 0)]
        public int? KnowledgeBaseId { get; set; }

        [Key, Column(Order = 1)]
        public int? TagId { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;

        [InverseProperty("KnowledgeBaseTags")]
        public Tag? Tag { get; set; }

        [InverseProperty("KnowledgeBaseTags")]
        public KnowledgeBaseLibrary? KnowledgeBaseLibrary { get; set; }
    }
}
