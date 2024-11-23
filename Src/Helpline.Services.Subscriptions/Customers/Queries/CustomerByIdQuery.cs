using Helpline.Contracts.v1.Responses;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Subscriptions.Customers.Queries
{
    public sealed record CustomerByIdQuery(Guid UserId) : IQuery<CustomerResponse>;
}
