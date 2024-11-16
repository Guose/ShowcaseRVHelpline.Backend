namespace Helpline.WebAPI.Controller.v1.SubscriptionService.Contracts
{
    public sealed record RegisterAddressRequest(
        string Address1,
        string Address2,
        string City,
        string State,
        string ZipCode);
}
