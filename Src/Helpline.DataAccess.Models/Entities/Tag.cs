using Helpline.DataAccess.Models.Entities.Associations;

namespace Helpline.DataAccess.Models.Entities
{
    public class Tag : BaseModel
    {
        public string TagName { get; set; } = string.Empty;
        public ICollection<ServiceCaseTag>? ServiceCaseTags { get; set; }
        public ICollection<KnowledgeBaseTag>? KnowledgeBaseTags { get; set; }
    }
}
