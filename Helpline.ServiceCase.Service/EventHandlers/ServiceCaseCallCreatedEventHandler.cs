﻿using Helpline.Domain.Events;
using Helpline.ServiceCaseService.Events;

namespace Helpline.ServiceCaseService.EventHandlers
{
    public class ServiceCaseCallCreatedEventHandler : IEventHandler<ServiceCaseCallCreatedEvent>
    {
        public Task HandleAsync(ServiceCaseCallCreatedEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
