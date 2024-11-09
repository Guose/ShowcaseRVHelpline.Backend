namespace Helpline.WebAPI.Controller.Contracts
{
    public sealed record RegisterUserWithAddressRequest(
        string FirstName,
        string LastName,
        string PhoneNumber,
        RegisterAddressRequest RequestAddress);
}
