using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceCaseCallServiceTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Services",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "Services",
                table: "Employees");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Technician",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Subscriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ServiceDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "RelatedServiceCases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ServiceCaseCalls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "RVRenter",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "RVRentals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Returns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "KnowledgeBaseLibraries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Dealerships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Dealerships",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "DealershipContacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Checkouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DealershipId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<byte>(type: "tinyint", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    TechnicianId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Technician_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technician",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceCaseCallServiceTypes",
                columns: table => new
                {
                    ServiceCaseCallId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCaseCallServiceTypes", x => new { x.ServiceCaseCallId, x.ServiceTypeId });
                    table.ForeignKey(
                        name: "FK_ServiceCaseCallServiceTypes_ServiceCaseCalls_ServiceCaseCallId",
                        column: x => x.ServiceCaseCallId,
                        principalTable: "ServiceCaseCalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceCaseCallServiceTypes_Services_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dealerships_AddressId",
                table: "Dealerships",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCaseCallServiceTypes_ServiceTypeId",
                table: "ServiceCaseCallServiceTypes",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_EmployeeId",
                table: "Services",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_TechnicianId",
                table: "Services",
                column: "TechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dealerships_Addresses_AddressId",
                table: "Dealerships",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dealerships_Addresses_AddressId",
                table: "Dealerships");

            migrationBuilder.DropTable(
                name: "ServiceCaseCallServiceTypes");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Dealerships_AddressId",
                table: "Dealerships");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ServiceDetails");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "RelatedServiceCases");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ServiceCaseCalls");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "RVRenter");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "RVRentals");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Returns");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "KnowledgeBaseLibraries");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Dealerships");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Dealerships");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "DealershipContacts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "DealershipId",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "Services",
                table: "Technician",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Services",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
