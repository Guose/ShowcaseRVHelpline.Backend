using AutoMapper;
using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Data;
using Helpline.Domain.Errors;
using Helpline.Domain.Messaging;
using Helpline.Domain.Shared;

namespace Helpline.UserServices.Technicians.Queries.Handlers
{
    public class TechnicianByUserIdQueryHandler : IQueryHandler<TechnicianByUserIdQuery, TechnicianResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TechnicianByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<TechnicianResponse>> Handle(TechnicianByUserIdQuery request, CancellationToken cancellationToken)
        {
            var technician = await unitOfWork.TechnicianRepo.GetTechnicianByUserIdAsync(request.UserId.ToString(), cancellationToken);

            if (technician is null)
            {
                return Result.Failure<TechnicianResponse>(CommonErrors.User.NotFound(request.UserId));
            }

            return mapper.Map<TechnicianResponse>(technician);
        }
    }
}
