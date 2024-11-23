using AutoMapper;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Data;
using Helpline.Domain.Errors;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.Employees.Commands.Handlers
{
    public class EmployeeUpdateCommandHandler : ICommandHandler<EmployeeUpdateCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result> Handle(EmployeeUpdateCommand request, CancellationToken cancellationToken)
        {
            var employee = await unitOfWork.EmployeeRepo.GetEmployeeByUserIdAsync(request.UserId.ToString(), cancellationToken);

            if (employee is null)
            {
                return Result.Failure(CommonErrors.User.NotFound(request.UserId));
            }

            var updatedEmployee = EmployeeRequest.Update(
                employee.Id,
                request.IsActive,
                new List<string>(request.Attachments),
                DateTime.Now);

            var response = mapper.Map<Employee>(updatedEmployee);

            if (!await unitOfWork.EmployeeRepo.UpdateEntityAsync(response, cancellationToken) &&
                !await unitOfWork.CompleteAsync(cancellationToken))
            {
                return Result.Failure<Guid>(new Error("Employee.Update", $"Update to employee profile {request.UserId} could not be completed."));
            }

            return Result.Success();
        }
    }
}
