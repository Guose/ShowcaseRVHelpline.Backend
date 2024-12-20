﻿using Helpline.Domain.Models.Entities.Associations;
using Helpline.Domain.Models.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Domain.Models.Entities
{
    public class ServiceCaseCall : BaseModel
    {
        public string? Caller { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public CallType CallType { get; set; }

        [ForeignKey("ServiceCaseId")]
        public Guid ServiceCaseId { get; set; }
        public ServiceCase? ServiceCase { get; set; }
        public string? Item { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public ServiceType ServiceType { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public ServiceCaseCallStatusType Status { get; set; }
        public DateTime ResolveDate { get; set; }


        [ForeignKey("KnowledgeBaseLibraryId")]
        public int KnowledgeBaseLibraryId { get; set; }
        public KnowledgeBaseLibrary? KnowledgeBaseLibrary { get; set; }

        public ICollection<ServiceCaseCallServiceClass>? ServiceCaseCallServiceClasses { get; set; }
    }
}