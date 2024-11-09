using Helpline.UserServices.DTOs.Requests;
using Helpline.UserServices.DTOs.Responses;
using MediatR;

namespace Helpline.UserServices.Commands
{
    public class UserCreateCommandRequest : IRequest<UserResponse>
    {
        public UserRequest UserRequest { get; }

        public UserCreateCommandRequest(UserRequest userRequest)
        {
            UserRequest = userRequest;
        }
    }
}
