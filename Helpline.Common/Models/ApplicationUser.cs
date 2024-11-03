using Helpline.Common.Types;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Helpline.Common.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Phone]
        public string? SecondaryPhone { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RoleType Role { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PermissionType Permssions { get; set; }
        public bool IsRemembered { get; set; } = false;
        public bool IsActive { get; set; } = true;

        [ForeignKey("AddressId")]
        public int AddressId { get; set; }
        public Address? Address { get; set; }

        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }
        public Technician? Technician { get; set; }
        public DealershipContact? DealershipContact { get; set; }

        [NotMapped]
        public string? Password { get; set; }
    }
}
