using Helpline.Contracts.v1.Requests;

namespace Helpline.WebAPI.Controller.v1.SubscriptionService.Contracts
{
    public sealed record RegisterUserWithAddressRequest(
        string FirstName,
        string LastName,
        string PhoneNumber,
        AddressRequest AddressRequest);
}
