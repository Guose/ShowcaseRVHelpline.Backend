using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomerVehicles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Customers",
            //    keyColumn: "Id",
            //    keyValue: -2);

            //migrationBuilder.DeleteData(
            //    table: "Customers",
            //    keyColumn: "Id",
            //    keyValue: -1);

            migrationBuilder.InsertData(
                table: "CustomerVehicles",
                columns: new[] { "Id", "Attachments", "BedTypes", "Chassis", "Class", "CreatedOn", "CustomerId", "Description", "FurnaceDefinition", "GeneratorDefinition", "GeneratorHours", "HasAwning", "HasCDPlayer", "HasDVDPlayer", "HasExteriorShower", "HasFireExtingusher", "HasFireplace", "HasFurnace", "HasGenerator", "HasInteriorShower", "HasMicrowave", "HasNavigation", "HasPropane", "HasRange", "HasRearVisionCamera", "HasRefrigerator", "HasRoofAC", "HasSlideout", "HasSnowChains", "HasTV", "HasWaterHeater", "HasiPodDocking", "Height", "IsActive", "IsBooked", "Length", "Make", "Manufacture", "Model", "ModifiedOn", "Notes", "Odometer", "PropaneDefinition", "RangeDefinition", "RefrigeratorDefinition", "SeatbeltsQty", "Sleeps", "SlideoutDefinition", "TVDefinition", "VIN", "Warranty", "WaterHeaterDefinition", "Year" },
                values: new object[,]
                {
                    { -3, null, null, "Ford", (byte)3, new DateTime(2024, 9, 27, 19, 14, 39, 90, DateTimeKind.Local).AddTicks(859), -2, null, null, null, 46, true, false, false, false, false, false, true, true, true, true, false, true, true, true, true, true, false, false, true, true, false, null, true, false, 25, "Freedom", "Thor", "Elite", null, null, 56412.0, null, null, null, 6, 6, null, null, null, null, null, 2017 },
                    { -2, null, null, "Ford", (byte)3, new DateTime(2024, 9, 27, 19, 14, 39, 90, DateTimeKind.Local).AddTicks(857), -1, null, null, null, 56, true, false, false, false, true, false, true, true, true, true, false, true, true, false, true, true, true, true, true, true, false, null, true, false, 27, "Sunseeker", "Forest River", "2560S", null, null, 79492.0, null, null, null, 7, 6, "Kitchenette", null, "1FDXE4FS1JDC19197", null, null, 2019 },
                    { -1, null, null, "Ford", (byte)3, new DateTime(2024, 9, 27, 19, 14, 39, 90, DateTimeKind.Local).AddTicks(797), -1, null, null, "Onan 4000", 80, true, false, false, false, true, false, true, true, true, true, false, true, true, true, true, true, false, true, true, true, false, null, true, false, 23, "Minnie Winnie", "Winnebago", "22R", null, null, 96519.0, null, null, null, 6, 6, null, null, "1FDWE3FL8EDA51997", null, null, 2015 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerVehicles",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "CustomerVehicles",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "CustomerVehicles",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Attachments", "CreatedOn", "Description", "IsActive", "ModifiedOn", "Notes", "SubscriptionEndDate", "SubscriptionId", "SubscriptionStartDate", "SubscriptionStatus", "SubscriptionType", "UserId" },
                values: new object[,]
                {
                    { -2, null, new DateTime(2024, 9, 27, 18, 12, 11, 163, DateTimeKind.Local).AddTicks(6058), null, true, null, null, new DateTime(2025, 5, 27, 18, 12, 11, 163, DateTimeKind.Local).AddTicks(6054), 1, new DateTime(2024, 5, 27, 18, 12, 11, 163, DateTimeKind.Local).AddTicks(6054), true, (byte)1, "45a55c7e-de7a-41ab-aceb-bc3d1701ccf1" },
                    { -1, null, new DateTime(2024, 9, 27, 18, 12, 11, 163, DateTimeKind.Local).AddTicks(6045), null, true, null, null, new DateTime(2025, 3, 27, 18, 12, 11, 163, DateTimeKind.Local).AddTicks(5973), 1, new DateTime(2024, 3, 27, 18, 12, 11, 163, DateTimeKind.Local).AddTicks(5973), true, (byte)1, "bc5a677b-c200-408f-9baa-52d7258256ae" }
                });
        }
    }
}
