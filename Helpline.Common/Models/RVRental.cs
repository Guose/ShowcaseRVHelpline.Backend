using Helpline.Common.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Common.Models
{
    public class RVRental : BaseModel
    {
        [Key]
        [Required]
        public new Guid Id { get; set; }

        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
        public RentalStatusType RentalStatus { get; set; }
        public int? CheckoutId { get; set; }
        [ForeignKey("CheckoutId")]
        public RVCheckout? Checkout { get; set; }
        public int? ReturnId { get; set; }
        [ForeignKey("ReturnId")]
        public RVReturn? Return { get; set; }

        public int? EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        public Guid? VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public CustomerVehicle? Vehicle { get; set; }

        public int? RenterId { get; set; }
        [ForeignKey("RenterId")]
        public RVRenter? Renter { get; set; }
    }
}
