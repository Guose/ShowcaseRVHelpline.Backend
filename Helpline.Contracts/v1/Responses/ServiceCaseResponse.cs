using Helpline.Common.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Helpline.Contracts.v1.Responses
{
    public class ServiceCaseResponse
    {
        public string Title { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ServiceCallSevType Sev { get; set; }
        public CustomerResponse? Customer { get; set; }
        public VehicleResponse? CustomerVehicle { get; set; }
        public EmployeeResponse? Employee { get; set; }
        public TechnicianResponse? Technician { get; set; }
    }
}
