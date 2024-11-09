using Helpline.Common.Essentials;
using Helpline.Common.Types;
using Helpline.Domain.ValueObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Helpline.UserServices.DTOs.Requests
{
    /// <summary>
    /// User that sends to the data access layer (DB)
    /// </summary>
    public sealed class UserRequest : AggregateRoot
    {
        private UserRequest(Guid id, FirstName firstName, LastName lastName, PhoneNumber phoneNumber, AddressRequest address) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
        }
        private UserRequest()
        {
        }

        public FirstName? FirstName { get; private set; }
        public LastName? LastName { get; private set; }
        public Email? Email { get; private set; }
        public UserName? UserName { get; private set; }
        public Password? Password { get; private set; }
        public PhoneNumber? PhoneNumber { get; private set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public RoleType Role { get; private set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PermissionType Permissions { get; private set; }
        public bool IsRemembered { get; private set; } = false;
        public bool IsActive { get; private set; } = true;
        public AddressRequest? Address { get; private set; }

        public static UserRequest Create(
            Guid id,
            FirstName firstName,
            LastName lastName,
            PhoneNumber phoneNumber,
            AddressRequest addressId)
        {
            var user = new UserRequest(
                id,
                firstName,
                lastName,
                phoneNumber,
                addressId);

            return user;
        }
    }
}
