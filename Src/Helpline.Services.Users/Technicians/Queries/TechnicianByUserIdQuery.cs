using Helpline.Contracts.v1.Responses;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.Technicians.Queries
{
    public sealed record TechnicianByUserIdQuery(Guid UserId) : IQuery<TechnicianResponse>;
}
