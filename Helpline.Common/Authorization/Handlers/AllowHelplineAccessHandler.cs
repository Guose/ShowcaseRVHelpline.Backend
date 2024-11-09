using Helpline.Common.Authorization.Requirements;
using Helpline.Common.Types;
using Microsoft.AspNetCore.Authorization;

namespace Helpline.Common.Authorization.Handlers
{
    public class AllowHelplineAccessHandler : AuthorizationHandler<HelplineAccessRequirment>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HelplineAccessRequirment requirement)
        {
            var roleClaim = context.User.FindFirst("RoleType")?.Value;
            var permissionClaim = context.User.FindFirst("PermissionType")?.Value;

            if (Enum.TryParse(roleClaim, out RoleType role) && Enum.TryParse(permissionClaim, out PermissionType permission))
            {
                if (role == requirement.RequiredRole && permission == requirement.RequiredPermission)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
