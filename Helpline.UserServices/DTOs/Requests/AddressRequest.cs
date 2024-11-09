using Helpline.Common.Essentials;

namespace Helpline.UserServices.DTOs.Requests
{
    public sealed class AddressRequest : AggregateRoot
    {
        private readonly List<UserRequest> _users = [];
        private AddressRequest()
        {
            Address1 = string.Empty;
            PostalCode = string.Empty;
        }
        private AddressRequest(
            int id,
            string address1,
            string address2,
            string city,
            string state,
            string zipCode) : base(id)
        {
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            PostalCode = zipCode;
        }

        public string Address1 { get; private set; }
        public string? Address2 { get; private set; }
        public string? City { get; private set; }
        public string? State { get; private set; }
        public string PostalCode { get; private set; }
        public string? County { get; private set; }
        public string? Country { get; private set; }
        public ICollection<UserRequest> Users => _users;

        public static AddressRequest Create(
            int id,
            string address1,
            string address2,
            string city,
            string state,
            string zipCode)
    {
            var address = new AddressRequest(
                id,
                address1,
                address2,
                city,
                state,
                zipCode);

            return address;
        }
    }
}
