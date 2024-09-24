using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Helpline.Shared.Types;

namespace Helpline.Shared.Models
{
    public class VehicleRvRenter
    {
        [Key, Column(Order = 0)]
        public int? RenterId { get; set; }

        [Key, Column(Order = 1)]
        public int? VehicleId { get; set; }
        public VehicleRentalStatus RentalStatus { get; set; }

        [InverseProperty("VehicleRvRenters")]
        public RVRenter? Renter { get; set; }

        [InverseProperty("VehicleRvRenters")]
        public CustomerVehicle? Vehicle { get; set; }
    }
}
