using Helpline.Contracts.v1.Types;
using Helpline.Domain.Events;
using Helpline.Domain.Models.CoreElements;

namespace Helpline.Contracts.v1.Requests
{
    /// <summary>
    /// User that sends to the data access layer (DB)
    /// </summary>
    public sealed class UserRequest : AggregateRoot, IAuditableEntity
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
        public RoleType Role { get; set; }
        public PermissionType Permissions { get; set; }
        public bool IsRemembered { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }

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

        public static UserRequest UpdateUserInfo(
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

        public void UpdateUserRoleAndPermission(RoleType role, PermissionType permissions)
        {
            if (Enum.IsDefined(typeof(RoleType), role) && Enum.IsDefined(typeof(PermissionType), permissions))
            {
                RaiseDomainEvent(new UserPermissionsChangedDomainEvent(Guid.NewGuid(), Id));
            }

            Role = role;
            Permissions = permissions;
        }
    }
}
