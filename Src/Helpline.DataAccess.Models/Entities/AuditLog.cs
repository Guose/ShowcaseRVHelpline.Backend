﻿using System.ComponentModel.DataAnnotations;

namespace Helpline.DataAccess.Models.Entities
{
    public class AuditLog : BaseModel
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string IPAddress { get; set; } = string.Empty;
        [Required]
        public string Method { get; set; } = string.Empty;
        [Required]
        public string Path { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }
    }
}