using Helpline.Shared.Types;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Shared.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Firstname { get; set; } = string.Empty;
        [Required]
        public string Lastname { get; set; } = string.Empty;
        [Phone]
        public string? SecondaryPhone { get; set; }
        [Required]
        public RoleType Role { get; set; }
        [Required]
        public PermissionType Permssions { get; set; } = PermissionType.None;
        public bool IsRemembered { get; set; } = false;

        public ICollection<Address>? Addresses { get; set; }

        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }
        public Technician? Technician { get; set; }
        public DealershipContact? DealershipContact { get; set; }

        [NotMapped]
        public string? Password { get; set; }
    }
}
