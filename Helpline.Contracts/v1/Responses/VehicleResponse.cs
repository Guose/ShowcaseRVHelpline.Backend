using Helpline.Common.Essentials;
using Helpline.Common.Models;
using Helpline.Common.Models.Associations;
using Helpline.Common.Types;

namespace Helpline.Contracts.v1.Responses
{
    public class VehicleResponse : AggregateRoot
    {
        private readonly List<ServiceCase> serviceCases = [];
        private readonly List<RVRental> rentals = [];
        private readonly List<VehicleRvRenter> vehicleRvRenters = [];

        public VehicleResponse(
            Guid id,
            int customerId) : base(id)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; set; }
        public int Year { get; set; }
        public RVClassType Class { get; set; }
        public string? Manufacture { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        public IReadOnlyCollection<ServiceCase> ServiceCases => serviceCases;
        public IReadOnlyCollection<RVRental> Rentals => rentals;
        public IReadOnlyCollection<VehicleRvRenter> VehicleRvRenters => vehicleRvRenters;
    }
}
