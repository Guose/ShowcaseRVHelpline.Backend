﻿using Helpline.Domain.Models.Types;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Helpline.API.UserIdentity.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public IEnumerable<SelectListItem>? RoleList { get; set; }

        [Display(Name = "Role")]
        public RoleType? RoleSelected { get; set; }

        [Display(Name = "Permission Claim")]
        public PermissionType? PermissionSelected { get; set; }
    }
}
