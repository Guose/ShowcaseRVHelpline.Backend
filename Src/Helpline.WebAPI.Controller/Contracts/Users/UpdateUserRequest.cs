namespace Helpline.WebAPI.Controller.Contracts.Users
{
    public sealed record UpdateUserRequest(
        string FirstName,
        string LastName,
        string PhoneNumber,
        string SecondPhone);
}
