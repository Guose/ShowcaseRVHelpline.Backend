using Helpline.Common.Types;

namespace Helpline.ServiceCallHub.DTOs
{
    public class ServiceCaseCallDto
    {
        public string? Caller { get; set; }
        public CallType? CallType { get; set; }
        public string? Item { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
