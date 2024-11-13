namespace Helpline.WebAPI.Controller.v1.ApplicationUsers.Contracts
{
    public sealed record UpdateUserRequest(
        string FirstName,
        string LastName,
        string PhoneNumber,
        string SecondPhone);
}
