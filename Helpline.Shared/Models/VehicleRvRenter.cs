using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Shared.Models
{
    public class VehicleRvRenter
    {
        public int? RenterId { get; set; }
        public int? VehicleId { get; set; }

        [InverseProperty("VehicleRvRenters")]
        public RVRenter? Renter { get; set; }

        [InverseProperty("VehicleRvRenters")]
        public CustomerVehicle? Vehicle { get; set; }
    }
}
