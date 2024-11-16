using Helpline.Common.Models.Associations;

namespace Helpline.Common.Models
{
    public class Tag : BaseModel
    {
        public string TagName { get; set; } = string.Empty;
        public ICollection<ServiceCaseTag>? ServiceCaseTags { get; set; }
        public ICollection<KnowledgeBaseTag>? KnowledgeBaseTags { get; set; }
    }
}
