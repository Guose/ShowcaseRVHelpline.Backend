namespace Helpline.WebAPI.Controller.v1.SubscriptionService.Contracts
{
    public sealed record UpdateUserRequest(
        string FirstName,
        string LastName,
        string PhoneNumber,
        string SecondPhone);
}
