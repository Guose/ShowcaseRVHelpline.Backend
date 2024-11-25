using Helpline.Contracts.v1.Types;

namespace Helpline.WebAPI.Controller.Contracts.Users
{
    public sealed record UpdateUserPermissionsRequest(RoleType RoleType, PermissionType PermissionType);
}
