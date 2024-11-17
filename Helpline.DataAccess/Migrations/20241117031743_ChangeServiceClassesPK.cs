using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeServiceClassesPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_EmployeeService_Employees_EmployeeId",
            //    table: "EmployeeService");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_EmployeeService_ServiceClasses_ServiceId",
            //    table: "EmployeeService");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_EmployeeService",
            //    table: "EmployeeService");

            //migrationBuilder.RenameTable(
            //    name: "EmployeeService",
            //    newName: "EmployeeServices");

            //migrationBuilder.RenameIndex(
            //    name: "IX_EmployeeService_ServiceId",
            //    table: "EmployeeServices",
            //    newName: "IX_EmployeeServices_ServiceId");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_EmployeeServices",
            //    table: "EmployeeServices",
            //    columns: ["EmployeeId", "ServiceId"]);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeeServices_Employees_EmployeeId",
            //    table: "EmployeeServices",
            //    column: "EmployeeId",
            //    principalTable: "Employees",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeeServices_ServiceClasses_ServiceId",
            //    table: "EmployeeServices",
            //    column: "ServiceId",
            //    principalTable: "ServiceClasses",
            //    principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_EmployeeServices_Employees_EmployeeId",
            //    table: "EmployeeServices");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_EmployeeServices_ServiceClasses_ServiceId",
            //    table: "EmployeeServices");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_EmployeeServices",
            //    table: "EmployeeServices");

            //migrationBuilder.RenameTable(
            //    name: "EmployeeServices",
            //    newName: "EmployeeService");

            //migrationBuilder.RenameIndex(
            //    name: "IX_EmployeeServices_ServiceId",
            //    table: "EmployeeService",
            //    newName: "IX_EmployeeService_ServiceId");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_EmployeeService",
            //    table: "EmployeeService",
            //    columns: ["EmployeeId", "ServiceId"]);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeeService_Employees_EmployeeId",
            //    table: "EmployeeService",
            //    column: "EmployeeId",
            //    principalTable: "Employees",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_EmployeeService_ServiceClasses_ServiceId",
            //    table: "EmployeeService",
            //    column: "ServiceId",
            //    principalTable: "ServiceClasses",
            //    principalColumn: "Id");
        }
    }
}
