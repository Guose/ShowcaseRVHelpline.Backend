using AutoMapper;
using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Data;
using Helpline.Domain.Errors;
using Helpline.Domain.Messaging;
using Helpline.Domain.Shared;

namespace Helpline.UserServices.Employees.Queries.Handlers
{
    public class EmployeesAllQueryHandler : IQueryHandler<EmployeesAllQuery, IEnumerable<EmployeeResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeesAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<IEnumerable<EmployeeResponse>>> Handle(EmployeesAllQuery request, CancellationToken cancellationToken)
        {
            var employees = await unitOfWork.EmployeeRepo.GetAllEntitiesAsync(cancellationToken);

            if (employees is null)
            {
                return Result.Failure<IEnumerable<EmployeeResponse>>(CommonErrors.User.AreNull);
            }

            var employeesDto = mapper.Map<IEnumerable<EmployeeResponse>>(employees);

            return Result.Success(EmployeeSummary(employeesDto));
        }

        private static IEnumerable<EmployeeResponse> EmployeeSummary(IEnumerable<EmployeeResponse> employees)
        {
            return employees.Select(e => EmployeeResponse.Create(
                e.User.FirstName + " " + e.User.LastName,
                e.Company,
                e.JobTitle,
                e.User,
                [.. e.ServiceCases]));
        }
    }
}
