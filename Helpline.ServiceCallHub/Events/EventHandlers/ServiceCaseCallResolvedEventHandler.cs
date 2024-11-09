using Helpline.Domain.Events;
using Helpline.ServiceCallHub.Events;

namespace Helpline.ServiceCallHub.Events.EventHandlers
{
    public class ServiceCaseCallResolvedEventHandler : IEventHandler<ServiceCaseCallResolvedEvent>
    {
        public Task HandleAsync(ServiceCaseCallResolvedEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
