namespace Helpline.Contracts.v1.Requests
{
    public sealed class AddressRequest
    {
        private AddressRequest()
        {
            Address1 = string.Empty;
            PostalCode = string.Empty;
        }
        private AddressRequest(
            string address1,
            string address2,
            string city,
            string state,
            string zipCode)
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

        public static AddressRequest Create(
            string address1,
            string address2,
            string city,
            string state,
            string zipCode)
        {
            var address = new AddressRequest(
                address1,
                address2,
                city,
                state,
                zipCode);

            return address;
        }
    }
}
