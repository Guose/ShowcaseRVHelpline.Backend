using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            //migrationBuilder.DeleteData(
            //    table: "Subscriptions",
            //    keyColumn: "Id",
            //    keyValue: 1);

            //migrationBuilder.DeleteData(
            //    table: "Subscriptions",
            //    keyColumn: "Id",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    table: "Subscriptions",
            //    keyColumn: "Id",
            //    keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerVehicleId",
                table: "ServiceCases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "ServiceCases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Attachments", "CreatedOn", "Description", "IsActive", "ModifiedOn", "Notes", "SubscriptionEndDate", "SubscriptionId", "SubscriptionStartDate", "SubscriptionStatus", "SubscriptionType", "UserId" },
                values: new object[,]
                {
                    { -2, null, new DateTime(2024, 9, 27, 18, 12, 11, 163, DateTimeKind.Local).AddTicks(6058), null, true, null, null, new DateTime(2025, 5, 27, 18, 12, 11, 163, DateTimeKind.Local).AddTicks(6054), 1, new DateTime(2024, 5, 27, 18, 12, 11, 163, DateTimeKind.Local).AddTicks(6054), true, (byte)1, "45a55c7e-de7a-41ab-aceb-bc3d1701ccf1" },
                    { -1, null, new DateTime(2024, 9, 27, 18, 12, 11, 163, DateTimeKind.Local).AddTicks(6045), null, true, null, null, new DateTime(2025, 3, 27, 18, 12, 11, 163, DateTimeKind.Local).AddTicks(5973), 1, new DateTime(2024, 3, 27, 18, 12, 11, 163, DateTimeKind.Local).AddTicks(5973), true, (byte)1, "bc5a677b-c200-408f-9baa-52d7258256ae" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerVehicleId",
                table: "ServiceCases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "ServiceCases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Attachments", "CreatedOn", "Description", "IsActive", "ModifiedOn", "Notes", "Price", "SubscriptionType", "Term" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 27, 12, 42, 59, 308, DateTimeKind.Local).AddTicks(3136), "24/7 access to Showcase RV Hub site for RV rentals", false, null, null, 20.00m, (byte)1, "Rental" },
                    { 2, null, new DateTime(2024, 9, 27, 12, 42, 59, 308, DateTimeKind.Local).AddTicks(3199), "24/7 access to Showcase RV Hub site for customers", false, null, null, 125.00m, (byte)2, "Annual" },
                    { 3, null, new DateTime(2024, 9, 27, 12, 42, 59, 308, DateTimeKind.Local).AddTicks(3203), "24/7 access to Showcase RV Hub with a certified tech on call", false, null, null, 200.00m, (byte)3, "Annual" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
