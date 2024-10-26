using Helpline.Domain.Events;
using Helpline.ServiceCallHub.Events;

namespace Helpline.ServiceCallHub.EventHandlers
{
    public class ServiceCaseCallCreatedEventHandler : IEventHandler<ServiceCaseCallCreatedEvent>
    {
        public Task HandleAsync(ServiceCaseCallCreatedEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
