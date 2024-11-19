namespace Helpline.Contracts.v1.Responses
{
    public class AddressResponse
    {
        public string Address1 { get; set; } = string.Empty;
        public string? City { get; set; }
        public string? State { get; set; }
        public string PostalCode { get; set; } = string.Empty;
    }
}
