using Helpline.Domain.Models.Entities.Associations;
using Helpline.Domain.Models.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Domain.Models.Entities
{
    public class KnowledgeBaseLibrary : BaseModel
    {
        public string? Title { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public ServiceType ServiceType { get; set; }
        public string? VideoURL { get; set; }
        public string? VideoDIY { get; set; }

        public ICollection<ServiceCaseCall>? ServiceCaseCalls { get; set; }
        public ICollection<KnowledgeBaseTag>? KnowledgeBaseTags { get; set; }
    }
}
