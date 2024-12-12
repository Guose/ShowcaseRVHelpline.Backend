using Helpline.Domain.Models.Types;
using Microsoft.AspNetCore.Authorization;

namespace Helpline.API.Controller.Config.Access
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
