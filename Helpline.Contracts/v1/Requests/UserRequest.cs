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
        private UserRequest(Guid id, string firstName, string lastName, string phoneNumber) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        private UserRequest(Guid id, string firstName, string lastName, string phoneNumber, string secondPhone) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            SecondaryPhone = secondPhone;
        }

        public UserRequest() { }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? SecondaryPhone { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public RoleType Role { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PermissionType Permssions { get; set; }
        public bool IsRemembered { get; set; }
        public bool IsActive { get; set; }

        public static UserRequest Create(
            Guid id,
            string firstName,
            string lastName,
            string phoneNumber)
        {
            var user = new UserRequest(
                id,
                firstName,
                lastName,
                phoneNumber);

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
