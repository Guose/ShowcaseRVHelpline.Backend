using Helpline.Contracts.v1.Types;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.ApplicationUsers.Commands
{
    public sealed record UserPermissionsUpdateCommand(
        Guid UserId,
        RoleType Role,
        PermissionType Permissions) : ICommand;
}
