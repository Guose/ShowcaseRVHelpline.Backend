using Helpline.Domain.Events;

namespace Helpline.ServiceCaseService.Events
{
    public class ServiceCaseCallResolvedEvent : IEvent
    {
        public int Id { get; set; }
        public DateTime CallEndTime { get; set; }

        public ServiceCaseCallResolvedEvent(int id, DateTime callEndTime)
        {
            Id = id;
            CallEndTime = callEndTime;
        }
    }
}
