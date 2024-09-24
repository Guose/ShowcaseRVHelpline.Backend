namespace Helpline.Shared.Models
{
    public class KnowledgeBaseLibrary : BaseModel
    {
        public string? Title { get; set; }
        public Tag? Tags { get; set; }
        public string? VideoURL { get; set; }
        public string? VideoDIY { get; set; }

        public ICollection<ServiceCaseCall>? ServiceCaseCalls { get; set; }
        public ICollection<KnowledgeBaseTag>? KnowledgeBaseTags { get; set; }
    }
}
