using Helpline.Common.Types;
using Microsoft.AspNetCore.Authorization;

namespace Helpline.Common.Authorization.Requirements
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
