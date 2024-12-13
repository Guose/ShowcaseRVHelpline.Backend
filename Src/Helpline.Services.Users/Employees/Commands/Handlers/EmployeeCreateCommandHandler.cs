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
    public class EmployeeCreateCommandHandler : ICommandHandler<EmployeeCreateCommand>
    {
        private readonly IEmployeeRepository employeeRepo;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IApplicationUserRepository userRepo;

        public EmployeeCreateCommandHandler(IEmployeeRepository employeeRepo, IUnitOfWork unitOfWork, IMapper mapper, IApplicationUserRepository userRepo)
        {
            this.employeeRepo = employeeRepo;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userRepo = userRepo;
        }

        public async Task<Result> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepo.GetEntityByIdAsync(request.UserId.ToString(), cancellationToken);

            if (user is null)
                return Result.Failure(DomainErrors.User.NotFound(request.UserId));

            var employee = EmployeeRequest.Create(
                Guid.Parse(user.Id),
                request.Company,
                request.JobTitle,
                DateTime.UtcNow);

            var mapResult = mapper.Map<Employee>(employee);

            if (mapResult is null)
                return Result.Failure(DomainErrors.Map.MappingError);

            var result = await employeeRepo.CreateEntityAsync(mapResult, cancellationToken);

            if (result.IsFailure)
                return Result.Failure(DomainErrors.User.CreateError(Guid.Parse(user.Id)));

            await unitOfWork.CompleteAsync(cancellationToken);

            return Result.Success(mapResult);
        }
    }
}
