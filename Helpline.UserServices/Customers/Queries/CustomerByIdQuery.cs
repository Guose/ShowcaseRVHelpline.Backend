using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Customers.Queries
{
    public sealed record CustomerByIdQuery(Guid UserId) : IQuery<CustomerResponse>;
}
