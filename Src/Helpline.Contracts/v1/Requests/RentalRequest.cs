using Helpline.Contracts.v1.Types;
using Helpline.Domain.Models.CoreElements;

namespace Helpline.Contracts.v1.Requests
{
    public sealed class RentalRequest : AggregateRoot
    {
        private RentalRequest(
            Guid id,
            DateTime startDate,
            DateTime endDate,
            int customerId,
            Guid vehicleId,
            int renterId) : base(id)
        {
            RentalStart = startDate;
            RentalEnd = endDate;
            CustomerId = customerId;
            VehicleId = vehicleId;
            RenterId = renterId;
        }

        public DateTime RentalStart { get; private set; }
        public DateTime RentalEnd { get; private set; }
        public RentalStatusType RentalStatus { get; private set; }
        public int CustomerId { get; private set; }
        public Guid VehicleId { get; private set; }
        public int RenterId { get; private set; }
        public bool IsActive { get; private set; }

        public static RentalRequest Create(
            Guid id,
            DateTime startDate,
            DateTime endDate,
            int customerId,
            Guid vehicle,
            int renterId)
        {
            var rental = new RentalRequest(
                id,
                startDate,
                endDate,
                customerId,
                vehicle,
                renterId);

            return rental;
        }
    }
}
