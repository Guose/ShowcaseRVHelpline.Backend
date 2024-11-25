using Helpline.Contracts.v1.Requests;

namespace Helpline.WebAPI.Controller.Contracts.Users
{
    public sealed record RegisterUserWithAddressRequest(
        string FirstName,
        string LastName,
        string PhoneNumber,
        AddressRequest AddressRequest);
}
