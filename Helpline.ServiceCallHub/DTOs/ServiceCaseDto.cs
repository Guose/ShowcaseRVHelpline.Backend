using Helpline.Common.Types;

namespace Helpline.ServiceCallHub.DTOs
{
    public class ServiceCaseDto
    {
        public string Title { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public ServiceCallSevType Sev { get; set; }
        public int CustomerId { get; set; }
        public int CustomerVehicleId { get; set; }
    }
}
