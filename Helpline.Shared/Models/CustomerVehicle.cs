using Helpline.Shared.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Shared.Models
{
    public class CustomerVehicle : BaseModel
    {
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Required]
        public int Year { get; set; }
        [Required]
        public RVClassType Class { get; set; }
        public string? Manufacture { get; set; }
        [Required]
        public string Make { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;
        public string? Chassis { get; set; }
        public double Odometer { get; set; }
        public int? Length { get; set; }
        public double? Height { get; set; }
        public string? VIN { get; set; }
        public string? Warranty { get; set; }
        public bool HasGenerator { get; set; } = false;
        public string? GeneratorDefinition { get; set; }
        public int GeneratorHours { get; set; }
        public bool HasSlideout { get; set; } = false;
        public string? SlideoutDefinition { get; set; }
        public bool HasPropane { get; set; }
        public string? PropaneDefinition { get; set; }
        public bool HasFurnace { get; set; }
        public string? FurnaceDefinition { get; set; }
        public bool HasWaterHeater { get; set; }
        public string? WaterHeaterDefinition { get; set; }
        public bool HasRange { get; set; }
        public string? RangeDefinition { get; set; }
        public bool HasRefrigerator { get; set; }
        public string? RefrigeratorDefinition { get; set; }
        public bool HasTV { get; set; }
        public string? TVDefinition { get; set; }
        public bool HasMicrowave { get; set; }
        public bool HasCDPlayer { get; set; }
        public bool HasDVDPlayer { get; set; }
        public bool HasAwning { get; set; }
        public bool HasRearVisionCamera { get; set; }
        public bool HasRoofAC { get; set; }
        public bool HasInteriorShower { get; set; }
        public bool HasExteriorShower { get; set; }
        public bool HasiPodDocking { get; set; }
        public bool HasNavigation { get; set; }
        public int Sleeps { get; set; }
        public int SeatbeltsQty { get; set; }
        public bool HasFireExtingusher { get; set; }
        public bool HasSnowChains { get; set; }
        public bool HasFireplace { get; set; }
        public bool IsBooked { get; set; } = false;

        public ICollection<ServiceCase>? ServiceCases { get; set; }
        public ICollection<RVRental>? Rentals { get; set; }
        public ICollection<VehicleRvRenter>? VehicleRvRenters { get; set; }
    }
}
