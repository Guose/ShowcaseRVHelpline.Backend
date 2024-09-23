using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Shared.Models
{
    public class KnowledgeBaseLibrary : BaseModel
    {
        public string? Title { get; set; }
        public Tags? Tags { get; set; }
        public string? VideoURL { get; set; }
        public string? VideoDIY { get; set; }

        public ICollection<ServiceCaseCall>? ServiceCaseCalls { get; set; }
    }
}
