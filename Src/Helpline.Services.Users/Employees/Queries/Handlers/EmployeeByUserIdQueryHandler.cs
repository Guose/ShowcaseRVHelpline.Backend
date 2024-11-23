using AutoMapper;
using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Data;
using Helpline.Domain.Errors;
using Helpline.Domain.Shared;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.Employees.Queries.Handlers
{
    public class EmployeeByUserIdQueryHandler : IQueryHandler<EmployeeByUserIdQuery, EmployeeResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<EmployeeResponse>> Handle(EmployeeByUserIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await unitOfWork.EmployeeRepo.GetEmployeeByUserIdAsync(request.UserId.ToString(), cancellationToken);

            if (employee is null)
            {
                return Result.Failure<EmployeeResponse>(CommonErrors.User.NotFound(request.UserId));
            }

            return mapper.Map<EmployeeResponse>(employee);
        }
    }
}
