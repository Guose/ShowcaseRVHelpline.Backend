using Helpline.Common.Types;
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
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Phone]
        public string? SecondaryPhone { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public RoleType Role { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public PermissionType Permissions { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }

        public bool IsRemembered { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("AddressId")]
        public int AddressId { get; set; }

        public Address? Address { get; set; }
        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }
        public Technician? Technician { get; set; }
        public DealershipContact? DealershipContact { get; set; }

        [NotMapped]
        public string? Password { get; set; }

        public ApplicationUser()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
        }
    }
}
