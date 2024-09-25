﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Shared.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; }
        
        public string? City { get; set; }
        public string? State { get; set; }
        [Required]
        public string PostalCode { get; set; } = string.Empty;
        public string? County { get; set; }
        public string? Country { get; set; }

        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        [ForeignKey("DealershipId")]
        public int? DealershipId { get; set; }
        public Dealership? Dealership { get; set; }
    }
}
