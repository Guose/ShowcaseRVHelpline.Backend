using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCheckoutReturns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_RVRentals_RentalId",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Returns_RVRentals_RentalId",
                table: "Returns");

            migrationBuilder.DropIndex(
                name: "IX_Returns_RentalId",
                table: "Returns");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_RentalId",
                table: "Checkouts");

            //migrationBuilder.DeleteData(
            //    table: "RVRentals",
            //    keyColumn: "Id",
            //    keyValue: -3);

            //migrationBuilder.DeleteData(
            //    table: "RVRentals",
            //    keyColumn: "Id",
            //    keyValue: -2);

            //migrationBuilder.DeleteData(
            //    table: "RVRentals",
            //    keyColumn: "Id",
            //    keyValue: -1);

            //migrationBuilder.DeleteData(
            //    table: "ServiceCaseCalls",
            //    keyColumn: "Id",
            //    keyValue: -2);

            //migrationBuilder.DeleteData(
            //    table: "ServiceCaseCalls",
            //    keyColumn: "Id",
            //    keyValue: -1);

            //migrationBuilder.DeleteData(
            //    table: "RVRenters",
            //    keyColumn: "Id",
            //    keyValue: -3);

            //migrationBuilder.DeleteData(
            //    table: "RVRenters",
            //    keyColumn: "Id",
            //    keyValue: -2);

            //migrationBuilder.DeleteData(
            //    table: "RVRenters",
            //    keyColumn: "Id",
            //    keyValue: -1);

            migrationBuilder.InsertData(
                table: "Checkouts",
                columns: new[] { "Id", "Attachments", "BlackWater", "CreatedOn", "Description", "FreshWater", "FuelLevel", "GrayWater", "IsACChecked", "IsActive", "IsAwningChecked", "IsExteriorCleaned", "IsFurnaceChecked", "IsHotwaterChecked", "IsInteriorCleaned", "IsMicrowaveChecked", "IsRefrigeratorFreezerChecked", "IsRenterTrained", "IsSignalsChecked", "IsSlideoutChecked", "IsStoveAndOvenChecked", "IsTiresChecked", "ModifiedOn", "Notes", "Propane", "RentalId" },
                values: new object[,]
                {
                    { -2, null, 1, new DateTime(2024, 9, 28, 13, 17, 35, 349, DateTimeKind.Local).AddTicks(2369), null, 5, 5, 1, true, true, true, true, true, true, true, true, true, true, true, true, true, true, null, null, 5, -2 },
                    { -1, null, 1, new DateTime(2024, 9, 28, 13, 17, 35, 349, DateTimeKind.Local).AddTicks(2319), null, 5, 5, 1, true, false, true, true, true, true, true, true, true, true, true, true, true, true, null, null, 5, -1 }
                });

            migrationBuilder.InsertData(
                table: "Returns",
                columns: new[] { "Id", "Attachments", "BlackWater", "CreatedOn", "Description", "FuelLevel", "GrayWater", "InsuranceClaimDefinition", "InsuranceClaimPhotos", "IsACChecked", "IsActive", "IsAwningChecked", "IsCheckInComplete", "IsExteriorCleaned", "IsFurnaceChecked", "IsHotwaterChecked", "IsInsuranceClaim", "IsInteriorCleaned", "IsMicrowaveChecked", "IsRefrigeratorFreezerChecked", "IsSignalsChecked", "IsSlideoutChecked", "IsStoveAndOvenChecked", "IsTiresChecked", "ModifiedOn", "Notes", "PhotosReturn", "Propane", "RentalId" },
                values: new object[] { -1, null, 2, new DateTime(2024, 9, 28, 13, 17, 35, 349, DateTimeKind.Local).AddTicks(3229), null, 4, 2, null, null, true, true, true, true, true, true, true, false, true, true, true, true, true, true, true, null, null, null, 5, -1 });

            migrationBuilder.CreateIndex(
                name: "IX_RVRentals_CheckoutId",
                table: "RVRentals",
                column: "CheckoutId",
                unique: true,
                filter: "[CheckoutId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RVRentals_ReturnId",
                table: "RVRentals",
                column: "ReturnId",
                unique: true,
                filter: "[ReturnId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RVRentals_Checkouts_CheckoutId",
                table: "RVRentals",
                column: "CheckoutId",
                principalTable: "Checkouts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RVRentals_Returns_ReturnId",
                table: "RVRentals",
                column: "ReturnId",
                principalTable: "Returns",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RVRentals_Checkouts_CheckoutId",
                table: "RVRentals");

            migrationBuilder.DropForeignKey(
                name: "FK_RVRentals_Returns_ReturnId",
                table: "RVRentals");

            migrationBuilder.DropIndex(
                name: "IX_RVRentals_CheckoutId",
                table: "RVRentals");

            migrationBuilder.DropIndex(
                name: "IX_RVRentals_ReturnId",
                table: "RVRentals");

            migrationBuilder.DeleteData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Checkouts",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Returns",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "RVRenters",
                columns: new[] { "Id", "Attachments", "CreatedOn", "Description", "Email", "FullName", "IsActive", "IsRepeatRenter", "MobilePhone", "ModifiedOn", "Notes", "RentalPortal", "UserId" },
                values: new object[,]
                {
                    { -3, null, new DateTime(2024, 9, 28, 13, 14, 11, 5, DateTimeKind.Local).AddTicks(3464), null, null, "Erica Rayter", true, false, null, null, null, "Outdoorsy", null },
                    { -2, null, new DateTime(2024, 9, 28, 13, 14, 11, 5, DateTimeKind.Local).AddTicks(3461), null, null, "Robert Jensen", true, true, null, null, null, "Good Sams", null },
                    { -1, null, new DateTime(2024, 9, 28, 13, 14, 11, 5, DateTimeKind.Local).AddTicks(3438), null, null, "Paul Csicsila", true, false, null, null, null, "RV Share", null }
                });

            migrationBuilder.InsertData(
                table: "ServiceCaseCalls",
                columns: new[] { "Id", "Attachments", "CallType", "Caller", "CreatedOn", "Description", "IsActive", "Item", "KnowledgeBaseLibraryId", "ModifiedOn", "Notes", "ResolveDate", "ServiceCaseId", "ServiceClass", "Status" },
                values: new object[,]
                {
                    { -2, null, (byte)4, "Jane Doe", new DateTime(2024, 9, 28, 13, 14, 11, 5, DateTimeKind.Local).AddTicks(2245), null, false, null, -2, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -2, (byte)18, 0 },
                    { -1, null, (byte)3, "John Doe", new DateTime(2024, 9, 28, 13, 14, 11, 5, DateTimeKind.Local).AddTicks(2186), null, false, null, -1, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -1, (byte)10, 0 }
                });

            migrationBuilder.InsertData(
                table: "RVRentals",
                columns: new[] { "Id", "Attachments", "CheckoutId", "CreatedOn", "Description", "EmployeeId", "IsActive", "ModifiedOn", "Notes", "RentalEnd", "RentalStart", "RentalStatus", "RenterId", "ReturnId", "VehicleId" },
                values: new object[,]
                {
                    { -3, null, null, new DateTime(2024, 9, 28, 13, 14, 11, 5, DateTimeKind.Local).AddTicks(4663), null, -1, false, null, null, new DateTime(2025, 1, 27, 13, 14, 11, 5, DateTimeKind.Local).AddTicks(4660), new DateTime(2024, 12, 28, 13, 14, 11, 5, DateTimeKind.Local).AddTicks(4660), 1, -3, null, -2 },
                    { -2, null, -2, new DateTime(2024, 9, 28, 13, 14, 11, 5, DateTimeKind.Local).AddTicks(4657), null, -1, false, null, null, new DateTime(2024, 10, 18, 13, 14, 11, 5, DateTimeKind.Local).AddTicks(4655), new DateTime(2024, 9, 18, 13, 14, 11, 5, DateTimeKind.Local).AddTicks(4655), 2, -2, null, -3 },
                    { -1, null, -1, new DateTime(2024, 9, 28, 13, 14, 11, 5, DateTimeKind.Local).AddTicks(4643), null, -1, false, null, null, new DateTime(2023, 12, 28, 13, 14, 11, 5, DateTimeKind.Local).AddTicks(4625), new DateTime(2023, 11, 28, 13, 14, 11, 5, DateTimeKind.Local).AddTicks(4625), 3, -1, -1, -1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Returns_RentalId",
                table: "Returns",
                column: "RentalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_RentalId",
                table: "Checkouts",
                column: "RentalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_RVRentals_RentalId",
                table: "Checkouts",
                column: "RentalId",
                principalTable: "RVRentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Returns_RVRentals_RentalId",
                table: "Returns",
                column: "RentalId",
                principalTable: "RVRentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
