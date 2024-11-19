using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Technicians.Queries
{
    public sealed record TechnicianByUserIdQuery(Guid UserId) : IQuery<TechnicianResponse>;
}
