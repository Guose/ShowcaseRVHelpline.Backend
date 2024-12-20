﻿using AutoMapper;
using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Data;
using Helpline.Domain.Shared;
using Helpline.Services.Abstractions.Messaging;

namespace Helpline.Services.Users.Technicians.Queries.Handlers
{
    public class TechniciansAllQueryHandler : IQueryHandler<TechniciansAllQuery, IEnumerable<TechnicianResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TechniciansAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task<Result<IEnumerable<TechnicianResponse>>> Handle(TechniciansAllQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
