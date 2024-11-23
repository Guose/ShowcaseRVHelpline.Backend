using Helpline.Contracts.v1.Types;
using Helpline.Domain.Models.CoreElements;

namespace Helpline.Contracts.v1.Requests
{
    public class ServiceCaseRequest : AggregateRoot
    {
        public string Title { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public ServiceCallSevType Sev { get; set; }
    }
}
