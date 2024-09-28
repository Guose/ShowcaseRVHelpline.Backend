using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedSubscriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Dealerships",
            //    keyColumn: "Id",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    table: "Dealerships",
            //    keyColumn: "Id",
            //    keyValue: 4);

            //migrationBuilder.DeleteData(
            //    table: "Dealerships",
            //    keyColumn: "Id",
            //    keyValue: 7);

            //migrationBuilder.DeleteData(
            //    table: "Dealerships",
            //    keyColumn: "Id",
            //    keyValue: 8);

            //migrationBuilder.DeleteData(
            //    table: "Employees",
            //    keyColumn: "Id",
            //    keyValue: -2);

            //migrationBuilder.DeleteData(
            //    table: "Employees",
            //    keyColumn: "Id",
            //    keyValue: -1);

            //migrationBuilder.DeleteData(
            //    table: "Technicians",
            //    keyColumn: "Id",
            //    keyValue: -2);

            //migrationBuilder.DeleteData(
            //    table: "Technicians",
            //    keyColumn: "Id",
            //    keyValue: -1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionStartDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionEndDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Attachments", "CreatedOn", "Description", "IsActive", "ModifiedOn", "Notes", "Price", "SubscriptionType", "Term" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 27, 12, 42, 59, 308, DateTimeKind.Local).AddTicks(3136), "24/7 access to Showcase RV Hub site for RV rentals", false, null, null, 20.00m, (byte)1, "Rental" },
                    { 2, null, new DateTime(2024, 9, 27, 12, 42, 59, 308, DateTimeKind.Local).AddTicks(3199), "24/7 access to Showcase RV Hub site for customers", false, null, null, 125.00m, (byte)2, "Annual" },
                    { 3, null, new DateTime(2024, 9, 27, 12, 42, 59, 308, DateTimeKind.Local).AddTicks(3203), "24/7 access to Showcase RV Hub with a certified tech on call", false, null, null, 200.00m, (byte)3, "Annual" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionStartDate",
                table: "Customers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionEndDate",
                table: "Customers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Dealerships",
                columns: new[] { "Id", "AddressId", "Attachments", "CreatedOn", "DealershipName", "Description", "IsActive", "ModifiedOn", "Notes", "PhoneNumber", "WebPage" },
                values: new object[,]
                {
                    { 2, -6, null, new DateTime(2024, 9, 26, 23, 4, 36, 427, DateTimeKind.Local).AddTicks(2311), "Camping World", null, false, null, null, "8552123307", "https://rv.campingworld.com/dealer/burlington-washington" },
                    { 4, -7, null, new DateTime(2024, 9, 26, 23, 4, 36, 427, DateTimeKind.Local).AddTicks(2375), "Camping World", null, false, null, null, "8773604375", "https://rv.campingworld.com/dealer/silverdale-wa" },
                    { 7, -8, null, new DateTime(2024, 9, 26, 23, 4, 36, 427, DateTimeKind.Local).AddTicks(2380), "Camping World", null, false, null, null, "8005264165", "https://rv.campingworld.com/location/fife-washington" },
                    { 8, -9, null, new DateTime(2024, 9, 26, 23, 4, 36, 427, DateTimeKind.Local).AddTicks(2384), "Roy Robinson RV", null, false, null, null, "3606596238", "https://www.royrobinsonrv.com" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Attachments", "Company", "CreatedOn", "Description", "IsActive", "JobTitle", "ModifiedOn", "Notes", "ReferralCode", "UserId" },
                values: new object[,]
                {
                    { -2, null, "Showcase Mobile RV", new DateTime(2024, 9, 26, 23, 4, 36, 427, DateTimeKind.Local).AddTicks(3824), null, false, "President", null, null, "SUNSEEKER", "4c57ce2c-78cc-4d35-9ae7-bf29b6ce2a46" },
                    { -1, null, "Showcase RV Hub", new DateTime(2024, 9, 26, 23, 4, 36, 427, DateTimeKind.Local).AddTicks(3802), null, false, "Founder/CEO", null, null, "TRAVEL", "bc5a677b-c200-408f-9baa-52d7258256ae" }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "Id", "Attachments", "Company", "CreatedOn", "Description", "IsActive", "IsW9OnFile", "ModifiedOn", "Notes", "ReferralCode", "UserId", "Website" },
                values: new object[,]
                {
                    { -2, null, "Les Schwab Tires", new DateTime(2024, 9, 26, 23, 4, 36, 427, DateTimeKind.Local).AddTicks(5260), null, false, false, null, null, null, null, null },
                    { -1, null, "Showcase Mobile RV Services", new DateTime(2024, 9, 26, 23, 4, 36, 427, DateTimeKind.Local).AddTicks(5239), null, true, false, null, null, "Scout", "b9ca97e2-1969-4181-b0b3-099c560a2125", null }
                });
        }
    }
}
