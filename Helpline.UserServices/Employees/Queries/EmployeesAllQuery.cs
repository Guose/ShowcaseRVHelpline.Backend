using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Messaging;

namespace Helpline.UserServices.Employees.Queries
{
    public sealed record EmployeesAllQuery() : IQuery<IEnumerable<EmployeeResponse>>;
}
