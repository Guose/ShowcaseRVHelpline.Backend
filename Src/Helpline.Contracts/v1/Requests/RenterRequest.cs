namespace Helpline.Contracts.v1.Requests
{
    public class RenterRequest
    {
        public string RentalPortal { get; set; } = string.Empty;
        public bool IsRepeatRenter { get; set; } = false;
        public UserRequest User { get; set; } = new();
    }
}
