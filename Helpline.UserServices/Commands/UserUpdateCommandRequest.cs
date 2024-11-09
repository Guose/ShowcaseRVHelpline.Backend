using Helpline.UserServices.DTOs.Requests;
using MediatR;

namespace Helpline.UserServices.Commands
{
    public class UserUpdateCommandRequest : IRequest<bool>
    {
        public UserRequest UserRequest { get; }
        public string UserId { get; set; } = string.Empty;

        public UserUpdateCommandRequest(UserRequest userRequest, string userId)
        {
            UserRequest = userRequest;
            UserId = userId;
        }
    }
}
