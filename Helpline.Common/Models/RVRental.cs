using Helpline.Common.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Common.Models
{
    public class RVRental : BaseModel
    {
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
        public RentalStatusType RentalStatus { get; set; }
        public int? CheckoutId { get; set; }
        public RVCheckout? Checkout { get; set; }
        public int? ReturnId { get; set; }
        public RVReturn? Return { get; set; }

        [ForeignKey("EmployeeId")]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [ForeignKey("VehicleId")]
        public int? VehicleId { get; set; }
        public CustomerVehicle? Vehicle { get; set; }

        [ForeignKey("RenterId")]
        public int? RenterId { get; set; }
        public RVRenter? Renter { get; set; }
    }
}
