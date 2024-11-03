﻿using Helpline.Domain.Commands;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Events;

namespace Helpline.ServiceCallHub.Commands.CommandHandlers
{
    public class CreateServiceCaseCommandHandler : ICommandHandler<CreateServiceCaseCallCommand>
    {
        private readonly IServiceCaseCallRepository serviceCaseCallRepository;
        private readonly IEventPublisher eventPublisher;

        public CreateServiceCaseCommandHandler(IServiceCaseCallRepository serviceCaseCallRepository, IEventPublisher eventPublisher)
        {
            this.serviceCaseCallRepository = serviceCaseCallRepository;
            this.eventPublisher = eventPublisher;
        }

        public async Task HandleAsync(CreateServiceCaseCallCommand command)
        {
            // Save to the repository
            await serviceCaseCallRepository.SaveAsync();

            // Optionally, publish events here if using an event bus
            // For each event in aggregate.Events, publish it
        }
    }
}
