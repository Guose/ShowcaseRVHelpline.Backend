using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Employees.Queries
{
    public sealed record EmployeeByUserIdQuery(Guid UserId) : IQuery<EmployeeResponse>;
}
