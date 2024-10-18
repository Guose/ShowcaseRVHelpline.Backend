using Helpline.Domain.Events;
using Helpline.ServiceCaseService.Events;

namespace Helpline.ServiceCaseService.EventHandlers
{
    public class ServiceCaseCallResolvedEventHandler : IEventHandler<ServiceCaseCallResolvedEvent>
    {
        public Task HandleAsync(ServiceCaseCallResolvedEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
