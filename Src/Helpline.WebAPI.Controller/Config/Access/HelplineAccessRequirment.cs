using Helpline.Domain.Models.Types;
using Microsoft.AspNetCore.Authorization;

namespace Helpline.WebAPI.Controller.Config.Access
{
    public class HelplineAccessRequirment : IAuthorizationRequirement
    {
        public HelplineAccessRequirment(RoleType role, PermissionType permission)
        {
            RequiredRole = role;
            RequiredPermission = permission;
        }

        public RoleType RequiredRole { get; set; }
        public PermissionType RequiredPermission { get; set; }
    }
}
