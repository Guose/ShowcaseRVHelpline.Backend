﻿using Helpline.Domain.Events;
using Helpline.ServiceCaseService.Events;

namespace Helpline.ServiceCaseService.EventHandlers
{
    public class ServiceCaseCallEscalatedEventHandler : IEventHandler<ServiceCaseCallEscalatedEvent>
    {
        public Task HandleAsync(ServiceCaseCallEscalatedEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
