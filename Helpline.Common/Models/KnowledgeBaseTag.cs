﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Common.Models
{
    public class KnowledgeBaseTag
    {
        public int? KnowledgeBaseId { get; set; }
        public int? TagId { get; set; }

        [InverseProperty("KnowledgeBaseTags")]
        public Tag? Tag { get; set; }

        [InverseProperty("KnowledgeBaseTags")]
        public KnowledgeBaseLibrary? KnowledgeBaseLibrary { get; set; }
    }
}
