namespace Helpline.Common.Events
{
    public class ServiceCaseCreatedEvent
    {
        public int Id { get; set; }

        public ServiceCaseCreatedEvent(int id)
        {
            Id = id;
        }

    }
}
