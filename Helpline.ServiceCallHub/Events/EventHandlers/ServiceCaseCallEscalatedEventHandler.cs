using Helpline.Domain.Events;
using Helpline.ServiceCallHub.Events;

namespace Helpline.ServiceCallHub.Events.EventHandlers
{
    public class ServiceCaseCallEscalatedEventHandler : IEventHandler<ServiceCaseCallEscalatedEvent>
    {
        public Task HandleAsync(ServiceCaseCallEscalatedEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
