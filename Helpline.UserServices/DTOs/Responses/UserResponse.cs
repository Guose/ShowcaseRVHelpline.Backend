using Helpline.Common.Types;

namespace Helpline.UserServices.DTOs.Responses
{
    /// <summary>
    /// User that is returned from data access layer (DB)
    /// </summary>
    public class UserResponse
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public RoleType Role { get; set; }
        public PermissionType Permssions { get; set; }
        public bool IsRemembered { get; set; }
        public bool IsActive { get; set; }
    }
}
