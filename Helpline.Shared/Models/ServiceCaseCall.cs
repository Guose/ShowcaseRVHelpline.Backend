using System.ComponentModel.DataAnnotations.Schema;
using Helpline.Shared.Types;

namespace Helpline.Shared.Models
{
    public class ServiceCaseCall : BaseModel
    {
        public ServiceType ServiceKType { get; set; }
        public string? Status { get; set; }
        public DateTime ResolveDate { get; set; }
        [ForeignKey("KnowledgeBaseLibraryId")]
        public int KnowledgeBaseLibraryId { get; set; }
        public KnowledgeBaseLibrary? KnowledgeBaseLibrary { get; set; }

        [ForeignKey("ServiceCaseId")]
        public int ServiceCaseId { get; set; }
        public ServiceCase? ServiceCase { get; set; }


        public ICollection<ServiceCase>? ServiceCases { get; set; }
    }
}