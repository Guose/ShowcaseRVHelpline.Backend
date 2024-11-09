namespace Helpline.WebAPI.Controller.Contracts
{
    public sealed record UpdateUserRequest(
        string FirstName,
        string LastName,
        string PhoneNumber,
        string SecondPhone);
}
