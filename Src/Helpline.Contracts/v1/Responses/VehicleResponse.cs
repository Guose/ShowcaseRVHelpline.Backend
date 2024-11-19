using Helpline.Contracts.v1.Types;

namespace Helpline.Contracts.v1.Responses
{
    public class VehicleResponse
    {
        private readonly List<ServiceCaseResponse> serviceCases = [];
        private readonly List<RVRentalResponse> rentals = [];
        private readonly List<VehicleRvRenterResponse> vehicleRvRenters = [];

        public VehicleResponse(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; set; }
        public int Year { get; set; }
        public RVClassType Class { get; set; }
        public string? Manufacture { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        public IReadOnlyCollection<ServiceCaseResponse> ServiceCases => serviceCases;
        public IReadOnlyCollection<RVRentalResponse> Rentals => rentals;
        public IReadOnlyCollection<VehicleRvRenterResponse> VehicleRvRenters => vehicleRvRenters;
    }
}
