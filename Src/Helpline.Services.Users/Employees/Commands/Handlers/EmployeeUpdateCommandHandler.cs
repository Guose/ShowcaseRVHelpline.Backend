using AutoMapper;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Data;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Errors;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.Employees.Commands.Handlers
{
    public class EmployeeUpdateCommandHandler : ICommandHandler<EmployeeUpdateCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmployeeRepository employeeRepo;
        private readonly IMapper mapper;

        public EmployeeUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmployeeRepository employeeRepo)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.employeeRepo = employeeRepo;
        }

        public async Task<Result> Handle(EmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            var employee = await employeeRepo.GetEmployeeByUserIdAsync(request.UserId.ToString(), cancellationToken);

            if (employee is null)
                return Result.Failure(DomainErrors.User.NotFound(request.UserId));

            var updatedEmployee = EmployeeRequest.Update(
                request.IsActive,
                request.ReferralCode,
                DateTime.UtcNow);

            var response = mapper.Map<Employee>(updatedEmployee);

            if (response is null)
                return Result.Failure(new Error("Employee.Mapping", "Failed to map EmployeeRequest to Employee."));

            var result = await employeeRepo.UpdateEntityAsync(response, cancellationToken);

            if (result.IsFailure)
            {
                return Result.Failure<Guid>(
                    new Error(
                        "Employee.UpdateUserInfo",
                        $"UpdateUserInfo to employee profile {request.UserId} could not be completed."));
            }

            await unitOfWork.CompleteAsync(cancellationToken);

            return Result.Success();
        }
    }
}
