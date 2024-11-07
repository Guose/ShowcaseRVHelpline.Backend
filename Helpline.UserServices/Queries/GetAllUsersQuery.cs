using Helpline.UserServices.DTOs.Responses;
using MediatR;

namespace Helpline.UserServices.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserResponse>>
    {

    }
}
