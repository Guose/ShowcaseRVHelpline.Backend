﻿using Helpline.Common.Types;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Helpline.Common.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }
        [Phone]
        public string? SecondaryPhone { get; private set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public RoleType Role { get; private set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public PermissionType Permissions { get; private set; }
        public bool IsRemembered { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }


        [ForeignKey("AddressId")]
        public int AddressId { get; private set; }


        public Address Address { get; set; } = new();
        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }
        public Technician? Technician { get; set; }
        public DealershipContact? DealershipContact { get; set; }

        [NotMapped]
        public string Password { get; private set; }

        public ApplicationUser()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Password = string.Empty;
        }
    }
}
