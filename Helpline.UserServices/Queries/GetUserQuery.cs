using Helpline.UserServices.DTOs.Responses;
using MediatR;

namespace Helpline.UserServices.Queries
{
    public class GetUserQuery : IRequest<UserResponse>
    {
        public string UserId { get; }

        public GetUserQuery(string userId)
        {
            UserId = userId;
        }
    }
}
