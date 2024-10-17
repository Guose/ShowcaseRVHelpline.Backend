using Helpline.Common.Types;

namespace Helpline.Common.Models
{
    public class KnowledgeBaseLibrary : BaseModel
    {
        public string? Title { get; set; }
        public ServiceType ServiceType { get; set; }
        public string? VideoURL { get; set; }
        public string? VideoDIY { get; set; }

        public ICollection<ServiceCaseCall>? ServiceCaseCalls { get; set; }
        public ICollection<KnowledgeBaseTag>? KnowledgeBaseTags { get; set; }
    }
}
