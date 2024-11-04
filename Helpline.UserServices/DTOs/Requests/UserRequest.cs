using Helpline.Common.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Helpline.UserServices.DTOs.Requests
{
    public class UserRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        [JsonConverter(typeof(StringEnumConverter))]
        public RoleType Role { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PermissionType Permssions { get; set; }
        public bool IsRemembered { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public AddressRequest Address { get; set; } = new();
    }
}
