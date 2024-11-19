﻿using Helpline.DataAccess.Models.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpline.DataAccess.Models.Entities
{
    public class RVCheckout : BaseModel
    {
        public Guid RentalId { get; set; }
        [ForeignKey("RentalId")]
        public RVRental? Rental { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public TankLevelType FuelLevel { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public TankLevelType FreshWater { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public TankLevelType BlackWater { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public TankLevelType GrayWater { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public TankLevelType Propane { get; set; }

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
        public bool IsRenterTrained { get; set; }

        ICollection<string>? PhotosOut { get; set; }
    }
}