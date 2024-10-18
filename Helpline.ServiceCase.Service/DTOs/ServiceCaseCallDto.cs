using Helpline.Common.Types;

namespace Helpline.ServiceCaseService.DTOs
{
    public class ServiceCaseCallDto
    {
        public string? Caller { get; set; }
        public CallType? CallType { get; set; }
        public string? Item { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
