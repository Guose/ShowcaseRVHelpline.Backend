using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmpTechDealer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dealerships",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dealerships",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dealerships",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Dealerships",
                keyColumn: "Id",
                keyValue: 8);

            //migrationBuilder.DeleteData(
            //    table: "RVServices",
            //    keyColumn: "Id",
            //    keyValue: 1);

            //migrationBuilder.DeleteData(
            //    table: "RVServices",
            //    keyColumn: "Id",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    table: "RVServices",
            //    keyColumn: "Id",
            //    keyValue: 3);

            //migrationBuilder.DeleteData(
            //    table: "RVServices",
            //    keyColumn: "Id",
            //    keyValue: 4);

            //migrationBuilder.DeleteData(
            //    table: "RVServices",
            //    keyColumn: "Id",
            //    keyValue: 5);

            //migrationBuilder.DeleteData(
            //    table: "RVServices",
            //    keyColumn: "Id",
            //    keyValue: 6);

            //migrationBuilder.DeleteData(
            //    table: "RVServices",
            //    keyColumn: "Id",
            //    keyValue: 7);

            //migrationBuilder.DeleteData(
            //    table: "RVServices",
            //    keyColumn: "Id",
            //    keyValue: 8);

            //migrationBuilder.DeleteData(
            //    table: "RVServices",
            //    keyColumn: "Id",
            //    keyValue: 9);

            //migrationBuilder.DeleteData(
            //    table: "RVServices",
            //    keyColumn: "Id",
            //    keyValue: 10);

            //migrationBuilder.DeleteData(
            //    table: "RVServices",
            //    keyColumn: "Id",
            //    keyValue: 11);

            //migrationBuilder.DeleteData(
            //    table: "RVServices",
            //    keyColumn: "Id",
            //    keyValue: 12);

            //migrationBuilder.DeleteData(
            //    table: "RVServices",
            //    keyColumn: "Id",
            //    keyValue: 13);

            //migrationBuilder.DeleteData(
            //    table: "Tags",
            //    keyColumn: "Id",
            //    keyValue: -6);

            //migrationBuilder.DeleteData(
            //    table: "Tags",
            //    keyColumn: "Id",
            //    keyValue: -5);

            //migrationBuilder.DeleteData(
            //    table: "Tags",
            //    keyColumn: "Id",
            //    keyValue: -4);

            //migrationBuilder.DeleteData(
            //    table: "Tags",
            //    keyColumn: "Id",
            //    keyValue: -3);

            //migrationBuilder.DeleteData(
            //    table: "Tags",
            //    keyColumn: "Id",
            //    keyValue: -2);

            //migrationBuilder.DeleteData(
            //    table: "Tags",
            //    keyColumn: "Id",
            //    keyValue: -1);

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: "45a55c7e-de7a-41ab-aceb-bc3d1701ccf1");

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: "4c57ce2c-78cc-4d35-9ae7-bf29b6ce2a46");

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: "69f01f45-545b-4e46-820f-2ace9794875f");

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: "b9ca97e2-1969-4181-b0b3-099c560a2125");

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: "bc5a677b-c200-408f-9baa-52d7258256ae");

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: "c26288f9-dd3a-48d6-b50f-58f7741732d5");

            //migrationBuilder.DeleteData(
            //    table: "Addresses",
            //    keyColumn: "Id",
            //    keyValue: -5);

            //migrationBuilder.DeleteData(
            //    table: "Addresses",
            //    keyColumn: "Id",
            //    keyValue: -4);

            //migrationBuilder.DeleteData(
            //    table: "Addresses",
            //    keyColumn: "Id",
            //    keyValue: -3);

            //migrationBuilder.DeleteData(
            //    table: "Addresses",
            //    keyColumn: "Id",
            //    keyValue: -2);

            //migrationBuilder.DeleteData(
            //    table: "Addresses",
            //    keyColumn: "Id",
            //    keyValue: -1);

            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "ServiceCases");

            migrationBuilder.DropColumn(
                name: "OpenedBy",
                table: "ServiceCases");

            migrationBuilder.InsertData(
                table: "Dealerships",
                columns: new[] { "Id", "AddressId", "Attachments", "CreatedOn", "DealershipName", "Description", "IsActive", "ModifiedOn", "Notes", "PhoneNumber", "WebPage" },
                values: new object[,]
                {
                    { -1, -6, null, new DateTime(2024, 9, 26, 23, 4, 36, 427, DateTimeKind.Local).AddTicks(2311), "Camping World", null, true, null, null, "8552123307", "https://rv.campingworld.com/dealer/burlington-washington" },
                    { -2, -7, null, new DateTime(2024, 9, 26, 23, 4, 36, 427, DateTimeKind.Local).AddTicks(2375), "Camping World", null, true, null, null, "8773604375", "https://rv.campingworld.com/dealer/silverdale-wa" },
                    { -3, -8, null, new DateTime(2024, 9, 26, 23, 4, 36, 427, DateTimeKind.Local).AddTicks(2380), "Camping World", null, true, null, null, "8005264165", "https://rv.campingworld.com/location/fife-washington" },
                    { -4, -9, null, new DateTime(2024, 9, 26, 23, 4, 36, 427, DateTimeKind.Local).AddTicks(2384), "Roy Robinson RV", null, true, null, null, "3606596238", "https://www.royrobinsonrv.com" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Attachments", "Company", "CreatedOn", "Description", "IsActive", "JobTitle", "ModifiedOn", "Notes", "ReferralCode", "UserId" },
                values: new object[,]
                {
                    { -2, null, "Showcase Mobile RV", new DateTime(2024, 9, 26, 23, 4, 36, 427, DateTimeKind.Local).AddTicks(3824), null, true, "President", null, null, "SUNSEEKER", "4c57ce2c-78cc-4d35-9ae7-bf29b6ce2a46" },
                    { -1, null, "Showcase RV Hub", new DateTime(2024, 9, 26, 23, 4, 36, 427, DateTimeKind.Local).AddTicks(3802), null, true, "Founder/CEO", null, null, "TRAVEL", "bc5a677b-c200-408f-9baa-52d7258256ae" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dealerships",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dealerships",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dealerships",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Dealerships",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Technicians",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AddColumn<int>(
                name: "AssignedTo",
                table: "ServiceCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpenedBy",
                table: "ServiceCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Address1", "Address2", "City", "Country", "County", "DealershipId", "PostalCode", "State" },
                values: new object[,]
                {
                    { -9, "15855 Smokey Point Blvd", null, "Marysville", "USA", "Snohomish", -4, "98271", "WA" },
                    { -8, "4650 16th St E", null, "Fife", "USA", "Pierce", -3, "98424", "WA" },
                    { -7, "11572 Clear Creek Rd NW", null, "Silverdale", "USA", "Kitsap", -2, "98383", "WA" },
                    { -6, "1535 Walton Dr", null, null, "USA", null, -1, "98233", null },
                    { -5, "12803 Hwy 99", null, "Everett", "USA", "Snohomish", null, "98204", "WA" },
                    { -4, "13102 43rd Ave NE", null, "Marysville", "USA", "Snohomish", null, "98271", "WA" },
                    { -3, "215 100th St SW D105", null, "Everett", "USA", "Snohomish", null, "98240", "WA" },
                    { -2, "11310 S Lake Stevens Rd", null, "Lake Stevens", "USA", "Snohomish", null, "98258", "WA" },
                    { -1, "1606 Rock Creek Ridge Blvd SW", null, "North Bend", "USA", "King", null, "98045", "WA" }
                });

            migrationBuilder.InsertData(
                table: "RVServices",
                columns: new[] { "Id", "Attachments", "CostPercent", "CreatedOn", "Description", "Frequency", "GrossProfitPercent", "IsActive", "ModifiedOn", "Notes", "RetailPrice", "ServiceType", "ServiceCode", "ServiceMethod", "UOM" },
                values: new object[,]
                {
                    { 1, null, 65m, new DateTime(2024, 9, 27, 4, 57, 13, 752, DateTimeKind.Utc).AddTicks(768), "Top off fluids, clean terminals and posts, test amps/volts, and apply anti-corrosive (up to 3 batteries).", "As needed", 35m, true, null, null, 135.00m, "Battery ServiceType", "M00001", "Mobile", "3 batteries" },
                    { 2, null, 65m, new DateTime(2024, 9, 27, 4, 57, 13, 752, DateTimeKind.Utc).AddTicks(771), "Clean and check battery and connections; visual inspection of exhaust system; clean spark arrester; replace air filter, change oil and filter; perform load test; replace fuel filter as necessary.", "150 hours", 35m, true, null, null, 240.00m, "Generator Tuneups", "M00002", "Mobile", "Each" },
                    { 3, null, 65m, new DateTime(2024, 9, 27, 4, 57, 13, 752, DateTimeKind.Utc).AddTicks(772), "Lube chassis, check transmission fluids, battery water level, check/add coolant level; inspect wiper blades, and top off washer fluid.", "5000 miles or 6 months", 35m, true, null, null, 160.00m, "Oil Changes", "M00003", "Mobile", "Each" },
                    { 4, null, 65m, new DateTime(2024, 9, 27, 4, 57, 13, 752, DateTimeKind.Utc).AddTicks(773), "Drain fresh water tank and water heater; blow out water lines with compressed air, including toilet, shower and sinks; fill P-Traps with anti-freeze; pump anti-freeze through water lines with water heater bypass; includes up to 2 gallons of anti-freeze.", "Winter", 35m, true, null, null, 105.00m, "Winterization", "M00004", "Mobile", "Each" },
                    { 5, null, 65m, new DateTime(2024, 9, 27, 4, 57, 13, 752, DateTimeKind.Utc).AddTicks(773), "Deep cleaning with disinfectant, including cabinets, microwave, refrigerator, toilet & shower, range/oven; clean carpets & upholstery; clean dash & windows; and check for leaks.", "As needed", 35m, true, null, null, 475.00m, "Detail - Interior", "M00005", "Mobile", "Each" },
                    { 6, null, 65m, new DateTime(2024, 9, 27, 4, 57, 13, 752, DateTimeKind.Utc).AddTicks(776), "Pressure wash; buff all four sides, using polishing compound; wax all four sides for fiberglass gel coats; clean windows, tires, and chrome.", "As needed", 35m, true, null, null, 675.00m, "Detail - Exterior", "M00006", "Mobile", "Each" },
                    { 7, null, 65m, new DateTime(2024, 9, 27, 4, 57, 13, 752, DateTimeKind.Utc).AddTicks(776), "Full exterior and interior detail.", "As needed", 35m, true, null, null, 1099.00m, "Detail - Full", "M00007", "Mobile", "Each" },
                    { 8, null, 65m, new DateTime(2024, 9, 27, 4, 57, 13, 752, DateTimeKind.Utc).AddTicks(777), "Clean roof with specially designed cleaning agents and apply UV-Blocking treatment to protect roof, and check for leaks & seal if necessary", "Annual", 35m, true, null, null, 500.00m, "Roof Maintenance", "M00008", "Mobile", "Each" },
                    { 9, null, 65m, new DateTime(2024, 9, 27, 4, 57, 13, 752, DateTimeKind.Utc).AddTicks(777), "Perform annually for operating safety and fuel efficiency. Clean main burner orifice; clean blower wheel; clean/Inspect/Adjust electrode assembly; test module board/inspect and clean board contacts; clean and inspect combustion chamber; inspect fan motor; clean and inspect vent tubes and outer casing; reassemble furnace using new gaskets.", "Annual", 35m, true, null, null, 200.00m, "Furnace ServiceType", "B00001", "Both", "Each" },
                    { 10, null, 65m, new DateTime(2024, 9, 27, 4, 57, 13, 752, DateTimeKind.Utc).AddTicks(778), "Recommended annually for operating safety and fuel efficiency. Check condition of anode rod; check relief valve; adjust burners and electrodes; check thermocouple; check module", "Annual", 35m, true, null, null, 105.00m, "Water Heater ServiceType", "B00002", "Both", "Each" },
                    { 11, null, 65m, new DateTime(2024, 9, 27, 4, 57, 13, 752, DateTimeKind.Utc).AddTicks(779), "Recommended annually to maintain trouble-free operation and long life. Verify unit is air tight in compartment; refrigerator is properly vented (roof and sidewall); clean and adjust burner and orifice; inspect and test all door seals; check LP pressure and proper voltage; clean roof vent and check baffle.", "Annual", 35m, true, null, null, 125.00m, "Refrigerator ServiceType", "B00003", "Both", "Each" },
                    { 12, null, 65m, new DateTime(2024, 9, 27, 4, 57, 13, 752, DateTimeKind.Utc).AddTicks(779), "Recommended annually to improve performance and operating efficiency. Examine shroud for cracks and damage; check compressor voltage; check compressor amperage; remove and clean A/C filter; clean and unclog A/C roof drains; check air temperature drop across the evaporator coil.", "Annual", 35m, true, null, null, 125.00m, "Air Conditioner ServiceType", "B00004", "Both", "Each" },
                    { 13, null, 65m, new DateTime(2024, 9, 27, 4, 57, 13, 752, DateTimeKind.Utc).AddTicks(780), "Perform annually to help keep appliances and accessories operating efficiently and provide trouble-free travels. Check all of the following for proper operation: antennas, water heater, awnings, furnace, refrigerator, TVs, DVD players, range/oven, washer/dryer, roof A/Cs.", "Annual", 35m, true, null, null, 200.00m, "Pre-Delivery Inspection", "S00001", "Shop", "Each" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Attachments", "CreatedOn", "Description", "IsActive", "ModifiedOn", "Notes", "TagName" },
                values: new object[,]
                {
                    { -6, null, new DateTime(2024, 9, 27, 4, 57, 13, 751, DateTimeKind.Utc).AddTicks(8476), null, true, null, null, "Electrical" },
                    { -5, null, new DateTime(2024, 9, 27, 4, 57, 13, 751, DateTimeKind.Utc).AddTicks(8473), null, true, null, null, "Water Heater" },
                    { -4, null, new DateTime(2024, 9, 27, 4, 57, 13, 751, DateTimeKind.Utc).AddTicks(8473), null, true, null, null, "Tires" },
                    { -3, null, new DateTime(2024, 9, 27, 4, 57, 13, 751, DateTimeKind.Utc).AddTicks(8472), null, true, null, null, "Generator" },
                    { -2, null, new DateTime(2024, 9, 27, 4, 57, 13, 751, DateTimeKind.Utc).AddTicks(8471), null, true, null, null, "Troubleshooting" },
                    { -1, null, new DateTime(2024, 9, 27, 4, 57, 13, 751, DateTimeKind.Utc).AddTicks(8466), null, true, null, null, "How to" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsRemembered", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Permssions", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecondaryPhone", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "45a55c7e-de7a-41ab-aceb-bc3d1701ccf1", 0, -4, "12505b18-5957-4579-93e7-cf7b1c091d90", "eric@showcaservhub.com", false, "Eric", false, "Shaw", false, null, null, null, "AQAAAAIAAYagAAAAENkxw5GTLknA9nHuC95VEqXZQvbTV/OPX+jiXoMAJpahaC+B9AVCxNhwlFurB05LVQ==", (byte)0, "4253087638", false, (byte)3, null, "c038cf83-2ce7-4dd3-ae41-73aba47aef99", false, "EricS" },
                    { "4c57ce2c-78cc-4d35-9ae7-bf29b6ce2a46", 0, -3, "42540be8-e60c-43d3-9db6-85c1acb3a0d9", "nicole@showcaservhub.com", false, "Nicole", false, "McPherson", false, null, null, null, "AQAAAAIAAYagAAAAEN+WwQIU9ltt0/SJLb3gqaUFAe0bZI6ZqTWUAP0qJ2AyPnc9hlVS01mw8RZwUdI3Bg==", (byte)0, "3605728448", false, (byte)2, null, "1c6f29ad-c3b2-4b2e-abce-d19e74552954", false, "NicoleM" },
                    { "69f01f45-545b-4e46-820f-2ace9794875f", 0, -5, "fad6b3dc-e306-48a1-b515-e921237e2ea0", "jacob@skyautorepair.com", false, "Jacob", false, "Skys", false, null, null, null, "AQAAAAIAAYagAAAAEOti+pAY8fSm9hzMuVTo5MSf58AlbFSjkYEEpi11dU5ijM5iLBRHRFMIEudotRtcOQ==", (byte)0, "4253068730", false, (byte)4, null, "427f7835-2e8d-4b85-85b3-bc603b11644b", false, "Jacob_Skys" },
                    { "b9ca97e2-1969-4181-b0b3-099c560a2125", 0, -3, "1dfc5207-ae4a-408e-9b9a-e7e40f9024fb", "keith.rvtech@gmail.com", false, "Keith", false, "McPherson", false, null, null, null, "AQAAAAIAAYagAAAAEL8JzBCDFK46D2aWkaoFWHfVAC+Zxx46P1ZKMyc1gDOUVuqriVRTkYwUJAliiXxayQ==", (byte)0, "3606319123", false, (byte)5, null, "b2e8a89f-bc07-4070-ac36-ce86b9a503a7", false, "KeithM" },
                    { "bc5a677b-c200-408f-9baa-52d7258256ae", 0, -2, "999ec8b8-e97e-4171-90be-4c46ab24d989", "john@showcasemi.com", false, "John", false, "Elder", false, null, null, null, "AQAAAAIAAYagAAAAEKYcBtgVjsiJ57p3JovwQWvehR8zJBIc1+Xh8k2aBnsHb86dUBwm82MBsWLCM+MbFg==", (byte)0, "4253302032", false, (byte)8, null, "9f8df77d-fa74-4e11-a57d-073e378343b4", false, "JohnE" },
                    { "c26288f9-dd3a-48d6-b50f-58f7741732d5", 0, -1, "e83b733e-4946-48fa-a52e-9f172a8f1cf3", "justin@showcasemi.com", false, "Justin", false, "Elder", false, null, null, null, "AQAAAAIAAYagAAAAEIk2i+wftXtKvSd1Nh82Dz1dseJVjvVHCLjLbBanyY/E8tCF5tlt0nggsIr9ZkqphA==", (byte)0, "4259234362", false, (byte)1, null, "ce1fca8e-6289-4731-b02c-a34407d074a5", false, "guose" }
                });
        }
    }
}
