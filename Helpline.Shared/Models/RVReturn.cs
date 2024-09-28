using Helpline.Shared.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Shared.Models
{
    public class RVReturn : BaseModel
    {
        public int RentalId { get; set; }
        [ForeignKey("RentalId")]
        public RVRental? Rental { get; set; }

        public bool IsExteriorCleaned { get; set; }
        public bool IsInteriorCleaned { get; set; }
        public bool IsSignalsChecked { get; set; }
        public bool IsAwningChecked { get; set; }
        public bool IsSlideoutChecked { get; set; }
        public bool IsMicrowaveChecked { get; set; }
        public bool IsRefrigeratorFreezerChecked { get; set; }
        public bool IsStoveAndOvenChecked { get; set; }
        public bool IsFurnaceChecked { get; set; }
        public bool IsHotwaterChecked { get; set; }
        public bool IsACChecked { get; set; }
        public bool IsTiresChecked { get; set; }
        public TankLevelType FuelLevel { get; set; }
        public TankLevelType BlackWater { get; set; }
        public TankLevelType GrayWater { get; set; }
        public TankLevelType Propane { get; set; }
        public bool IsCheckInComplete { get; set; }
        public bool IsInsuranceClaim { get; set; }
        public string? InsuranceClaimDefinition { get; set; }
        public ICollection<string>? InsuranceClaimPhotos { get; set; }
        public ICollection<string>? PhotosReturn { get; set; }
    }
}
