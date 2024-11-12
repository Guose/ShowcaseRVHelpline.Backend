namespace Helpline.WebAPI.Controller.v1.ApplicationUsers.Contracts
{
    public sealed record RegisterUserWithAddressRequest(
        string FirstName,
        string LastName,
        string PhoneNumber,
        RegisterAddressRequest RequestAddress);
}
