using Helpline.Shared.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Shared.Models
{
    public class RVRental : BaseModel
    {
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }

        [ForeignKey("CheckoutId")]
        public int CheckoutId { get; set; }
        public RVCheckout? Checkout { get; set; }

        [ForeignKey("ReturnId")]
        public int ReturnId { get; set; }
        public RVReturn? Return { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [ForeignKey("VehicleId")]
        public int VehicleId { get; set; }
        public CustomerVehicle? Vehicle { get; set; }

        [ForeignKey("RenterId")]
        public int RenterId { get; set; }
        public RVRenter? Renter { get; set; }
    }
}
