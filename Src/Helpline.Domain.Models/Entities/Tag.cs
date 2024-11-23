using Helpline.Domain.Models.Entities.Associations;

namespace Helpline.Domain.Models.Entities
{
    public class Tag : BaseModel
    {
        public string TagName { get; set; } = string.Empty;
        public ICollection<ServiceCaseTag>? ServiceCaseTags { get; set; }
        public ICollection<KnowledgeBaseTag>? KnowledgeBaseTags { get; set; }
    }
}
