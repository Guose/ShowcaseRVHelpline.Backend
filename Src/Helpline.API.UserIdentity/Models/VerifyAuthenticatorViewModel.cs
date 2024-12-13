using System.ComponentModel.DataAnnotations;

namespace Helpline.API.UserIdentity.Models
{
    public class VerifyAuthenticatorViewModel
    {
        [Required]
        public string Code { get; set; } = string.Empty;
        public string? ReturnUrl { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
