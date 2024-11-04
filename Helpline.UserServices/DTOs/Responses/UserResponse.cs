using System.Text.Json.Serialization;
using Helpline.Common.Types;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json.Converters;

namespace Helpline.UserServices.DTOs.Responses
{
    public class UserResponse
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public RoleType Role { get; set; }
        public PermissionType Permssions { get; set; }
        public bool IsRemembered { get; set; }
        public bool IsActive { get; set; }
        public AddressResponse? Address { get; set; }
    }
}
