using Helpline.UserServices.DTOs.Requests;
using MediatR;

namespace Helpline.UserServices.Commands
{
    public class UserDeleteCommandRequest : IRequest<bool>
    {
        public string UserId { get; }

        public UserDeleteCommandRequest(string userId)
        {
            UserId = userId;
        }
    }
}
