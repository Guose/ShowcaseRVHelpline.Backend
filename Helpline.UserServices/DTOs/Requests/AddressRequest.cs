namespace Helpline.UserServices.DTOs.Requests
{
    public class AddressRequest
    {
        public string Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string? County { get; set; }
        public string? Country { get; set; }
    }
}
