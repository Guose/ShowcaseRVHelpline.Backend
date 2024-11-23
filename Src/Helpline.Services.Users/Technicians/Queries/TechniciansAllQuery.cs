using Helpline.Contracts.v1.Responses;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.Technicians.Queries
{
    public sealed record TechniciansAllQuery() : IQuery<IEnumerable<TechnicianResponse>>;
}
