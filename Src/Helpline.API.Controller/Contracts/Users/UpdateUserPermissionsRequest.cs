using Helpline.Contracts.v1.Types;

namespace Helpline.API.Controller.Contracts.Users
{
    public sealed record UpdateUserPermissionsRequest(RoleType RoleType, PermissionType PermissionType);
}
