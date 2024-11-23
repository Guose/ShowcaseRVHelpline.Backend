using Helpline.Domain.Models.Entities.Associations;
using Helpline.Domain.Models.Helpers;
using Helpline.Domain.Models.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.Domain.Models.Entities
{
    public class CustomerVehicle : BaseModel
    {
        private readonly IDictionaryConvertable<BedType, int> bedTypeDictionaryHelper;
        private readonly IDictionaryConvertable<VehicleFeaturesType, bool> vehicleFeaturesDictionaryHelper;
        public CustomerVehicle(IDictionaryConvertable<BedType, int> bedTypeDictionaryHelper, string bedDetails, IDictionaryConvertable<VehicleFeaturesType, bool> vehicleFeaturesDictionaryHelper)
        {
            BedDetails = bedDetails;
            this.bedTypeDictionaryHelper = bedTypeDictionaryHelper;
            this.vehicleFeaturesDictionaryHelper = vehicleFeaturesDictionaryHelper;
        }

        public CustomerVehicle()
        {
            bedTypeDictionaryHelper = new DictionaryHelper<BedType, int>();
            vehicleFeaturesDictionaryHelper = new DictionaryHelper<VehicleFeaturesType, bool>();
        }

        [Key]
        [Required]
        public new Guid Id { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        [JsonIgnore]
        public Customer? Customer { get; set; }

        public ICollection<ServiceCase>? ServiceCases { get; set; }
        public ICollection<RVRental>? Rentals { get; set; }
        public ICollection<VehicleRvRenter>? VehicleRvRenters { get; set; }

        [Required]
        public string BedDetails { get; set; } = "[]";

        [Required]
        public string FeatureDetails { get; set; } = "[]";

        [NotMapped]
        public IDictionary<BedType, int> Beds
        {
            get => bedTypeDictionaryHelper.ConvertToDictionary(BedDetails);
            set => BedDetails = bedTypeDictionaryHelper.ConvertToJsonAsync(value).Result;
        }

        [NotMapped]
        public IDictionary<VehicleFeaturesType, bool> Features
        {
            get => vehicleFeaturesDictionaryHelper.ConvertToDictionary(FeatureDetails);
            set => FeatureDetails = vehicleFeaturesDictionaryHelper.ConvertToJsonAsync(value).Result;
        }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public RVClassType Class { get; set; }

        [Required]
        public int Year { get; set; }
        public string? Manufacture { get; set; }

        [Required]
        public string Make { get; set; } = string.Empty;

        [Required]
        public string Model { get; set; } = string.Empty;
        public string? Chassis { get; set; }
        public double Odometer { get; set; }
        public int? Length { get; set; }
        public double? Height { get; set; }
        public int Sleeps { get; set; }
        public int SeatbeltsQty { get; set; }
        public string? VIN { get; set; }
        public string? Warranty { get; set; }
        public int GeneratorHours { get; set; }
        public bool IsBooked { get; set; } = false;
        public string? GeneratorDefinition { get; set; }
        public string? SlideoutDefinition { get; set; }
        public string? PropaneDefinition { get; set; }
        public string? FurnaceDefinition { get; set; }
        public string? WaterHeaterDefinition { get; set; }
        public string? RangeDefinition { get; set; }
        public string? RefrigeratorDefinition { get; set; }
        public string? TVDefinition { get; set; }
    }
}
