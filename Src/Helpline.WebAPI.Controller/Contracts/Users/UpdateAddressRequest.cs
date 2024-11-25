namespace Helpline.WebAPI.Controller.Contracts.Users
{
    public sealed record UpdateAddressRequest(
        string Address1,
        string Address2,
        string City,
        string State,
        string ZipCode);
}
