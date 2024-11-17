using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedServCallsRenterRentals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            //migrationBuilder.DeleteData(
            //    table: "KnowledgeBaseLibraries",
            //    keyColumn: "Id",
            //    keyValue: -2);

            //migrationBuilder.DeleteData(
            //    table: "KnowledgeBaseLibraries",
            //    keyColumn: "Id",
            //    keyValue: -1);

            //migrationBuilder.DeleteData(
            //    table: "ServiceCases",
            //    keyColumn: "Id",
            //    keyValue: -2);

            //migrationBuilder.DeleteData(
            //    table: "ServiceCases",
            //    keyColumn: "Id",
            //    keyValue: -1);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 1);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 3);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 4);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 5);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 6);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 7);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 8);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 9);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 10);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 11);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 12);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 13);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 14);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 15);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 16);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 17);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 18);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 19);

            //migrationBuilder.DeleteData(
            //    table: "ServiceClasses",
            //    keyColumn: "Id",
            //    keyValue: 20);

            migrationBuilder.AddColumn<int>(
                name: "FreshWater",
                table: "Checkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "RVRentals",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "RVRentals",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "RVRentals",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "ServiceCaseCalls",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "ServiceCaseCalls",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "RVRenters",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "RVRenters",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "RVRenters",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "FreshWater",
                table: "Checkouts");

            migrationBuilder.InsertData(
                table: "KnowledgeBaseLibraries",
                columns: new[] { "Id", "Attachments", "CreatedOn", "Description", "IsActive", "ModifiedOn", "Notes", "ServiceClass", "Title", "VideoDIY", "VideoURL" },
                values: new object[,]
                {
                    { -2, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(6560), "rv water heater troubleshooting", false, null, null, (byte)3, "Won't ignite", null, "https://www.bing.com/videos/search?&q=rv+water+heater+troubleshooting&view=detail&mid=4229C6383CE098F3696B4229C6383CE098F3696B&FORM=VDRVRV&ru=%2Fvideos%2Fsearch%3Fq%3Drv%2Bwater%2Bheater%2Btroubleshooting%26FORM%3DHDRSC3&rvsmid=E4CDD1246F058D189852E4CDD1246F058D189852&ajaxhist=0" },
                    { -1, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(6540), "how to tuneup rv onan generator", false, null, null, (byte)2, "How To", null, "https://www.bing.com/videos/search?q=how+to+tuneup+rv+onan+generator&&view=detail&mid=7ED4F475D1C846BE5A5B7ED4F475D1C846BE5A5B&&FORM=VRDGAR&ru=%2Fvideos%2Fsearch%3Fq%3Dhow%2Bto%2Btuneup%2Brv%2Bonan%2Bgenerator%26FORM%3DHDRSC3" }
                });

            migrationBuilder.InsertData(
                table: "ServiceCases",
                columns: new[] { "Id", "Attachments", "CreatedOn", "CustomerId", "CustomerVehicleId", "Description", "DueDate", "EmployeeId", "IsActive", "ModifiedOn", "Notes", "ServiceCaseCallId", "Sev", "TechnicianId", "Title" },
                values: new object[,]
                {
                    { -2, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(5094), 0, 0, "Tires are worn, drivers rear", new DateTime(2025, 7, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(5090), -1, true, null, null, null, 5, -2, "Tires" },
                    { -1, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(5078), 0, 0, "RV won't start", new DateTime(2025, 7, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(5057), -1, true, null, null, null, 3, -1, "Electrical Issue" }
                });

            migrationBuilder.InsertData(
                table: "ServiceClasses",
                columns: new[] { "Id", "Attachments", "CreatedOn", "Description", "IsActive", "ModifiedOn", "Notes", "ServiceClass" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3316), null, true, null, null, (byte)6 },
                    { 2, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3384), null, true, null, null, (byte)1 },
                    { 3, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3388), null, true, null, null, (byte)7 },
                    { 4, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3392), null, true, null, null, (byte)20 },
                    { 5, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3396), null, true, null, null, (byte)8 },
                    { 6, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3401), null, true, null, null, (byte)9 },
                    { 7, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3406), null, true, null, null, (byte)10 },
                    { 8, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3410), null, true, null, null, (byte)11 },
                    { 9, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3413), null, true, null, null, (byte)2 },
                    { 10, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3418), null, true, null, null, (byte)12 },
                    { 11, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3422), null, true, null, null, (byte)13 },
                    { 12, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3426), null, true, null, null, (byte)14 },
                    { 13, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3429), null, true, null, null, (byte)4 },
                    { 14, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3433), null, true, null, null, (byte)15 },
                    { 15, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3437), null, true, null, null, (byte)5 },
                    { 16, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3441), null, true, null, null, (byte)16 },
                    { 17, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3444), null, true, null, null, (byte)17 },
                    { 18, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3450), null, true, null, null, (byte)18 },
                    { 19, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3454), null, true, null, null, (byte)19 },
                    { 20, null, new DateTime(2024, 9, 27, 21, 25, 42, 460, DateTimeKind.Local).AddTicks(3457), null, true, null, null, (byte)3 }
                });

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
    }
}
