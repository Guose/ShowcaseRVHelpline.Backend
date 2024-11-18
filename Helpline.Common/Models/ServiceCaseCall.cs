﻿using Helpline.Common.Models.Associations;
using Helpline.Common.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Common.Models
{
    public class ServiceCaseCall : BaseModel
    {
        public string? Caller { get; set; }
        public CallType? CallType { get; set; }

        [ForeignKey("ServiceCaseId")]
        public Guid ServiceCaseId { get; set; }
        public ServiceCase? ServiceCase { get; set; }
        public string? Item { get; set; }
        public ServiceType ServiceType { get; set; }
        public ServiceCaseCallStatusType Status { get; set; }
        public DateTime ResolveDate { get; set; }


        [ForeignKey("KnowledgeBaseLibraryId")]
        public int KnowledgeBaseLibraryId { get; set; }
        public KnowledgeBaseLibrary? KnowledgeBaseLibrary { get; set; }

        public ICollection<ServiceCaseCallServiceClass>? ServiceCaseCallServiceClasses { get; set; }
    }
}