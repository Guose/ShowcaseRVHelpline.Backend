using Helpline.Common.Essentials;
using Helpline.Common.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Helpline.Contracts.v1.Requests
{
    /// <summary>
    /// User that sends to the data access layer (DB)
    /// </summary>
    public sealed class UserRequest : AggregateRoot
    {
        private UserRequest(Guid id, string firstName, string lastName, string phoneNumber, AddressRequest address) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        private UserRequest(Guid id, string firstName, string lastName, string phoneNumber, string secondPhone) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            SecondaryPhone = secondPhone;
        }

        public UserRequest() { }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public string? SecondaryPhone { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public RoleType Role { get; private set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PermissionType Permissions { get; private set; }
        public bool IsRemembered { get; private set; } = false;
        public bool IsActive { get; private set; } = true;
        public AddressRequest? Address { get; set; }

        public static UserRequest Create(
            Guid id,
            string firstName,
            string lastName,
            string phoneNumber,
            AddressRequest address)
        {
            var user = new UserRequest(
                id,
                firstName,
                lastName,
                phoneNumber,
                address);

            return user;
        }

        public static UserRequest Update(
            Guid id,
            string firstName,
            string lastName,
            string phoneNumber,
            string secondPhone)
        {
            var user = new UserRequest(
                id,
                firstName,
                lastName,
                phoneNumber,
                secondPhone);

            return user;
        }
    }
}
