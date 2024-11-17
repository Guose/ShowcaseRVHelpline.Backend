using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangePrimaryKeyNamesForServiceClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop foreign key constraints that depend on ServiceTypes
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeService_ServiceTypes_ServiceId",
                table: "EmployeeService");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicianServices_ServiceTypes_ServiceId",
                table: "TechnicianServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCaseCallServiceTypes_ServiceCaseCalls_ServiceCaseCallId",
                table: "ServiceCaseCallServiceClasses");

            // Drop the primary keys that are dependent on ServiceTypes
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceCaseCallServiceTypes",
                table: "ServiceCaseCallServiceClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeService",
                table: "EmployeeService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechnicianServices",
                table: "TechnicianServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceTypes",
                table: "ServiceClasses");


            // Rename EmployeeService table to EmployeeServices
            migrationBuilder.RenameTable(
                name: "EmployeeService",
                newName: "EmployeeServices");


            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceClasses",
                table: "ServiceClasses",
                column: "Id");

            // Add new foreign keys that reference ServiceClasses
            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeService_ServiceClasses_ServiceId",
                table: "EmployeeServices",
                column: "ServiceId",
                principalTable: "ServiceClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicianServices_ServiceClasses_ServiceId",
                table: "TechnicianServices",
                column: "ServiceId",
                principalTable: "ServiceClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCaseCallServiceClasses_ServiceCaseCalls_ServiceCaseCallId",
                table: "ServiceCaseCallServiceClasses",
                column: "ServiceClassId",
                principalTable: "ServiceClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            // Add primary key constraints for the tables that were previously dropped
            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceCaseCallServiceClasses",
                table: "ServiceCaseCallServiceClasses",
                columns: ["ServiceCaseCallId", "ServiceClassId"]);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeServices",
                table: "EmployeeServices",
                columns: ["EmployeeId", "ServiceId"]);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechnicianServices",
                table: "TechnicianServices",
                columns: ["TechnicianId", "ServiceId"]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop new foreign keys that reference ServiceClasses
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeService_ServiceClasses_ServiceId",
                table: "EmployeeServices");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicianServices_ServiceClasses_ServiceId",
                table: "TechnicianServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCaseCallServiceClass_ServiceClasses_ServiceClassId",
                table: "ServiceCaseCallServiceClasses");

            // Drop new primary keys
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceCaseCallServiceClasses",
                table: "ServiceCaseCallServiceClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeServices",
                table: "EmployeeServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechnicianServices",
                table: "TechnicianServices");


            // Rename EmployeeServices table to EmployeeService
            migrationBuilder.RenameTable(
                name: "EmployeeServices",
                newName: "EmployeeService");



            // Add old foreign keys that reference ServiceTypes back
            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeService_ServiceTypes_ServiceId",
                table: "EmployeeServices",
                column: "ServiceId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicianServices_ServiceTypes_ServiceId",
                table: "TechnicianServices",
                column: "ServiceId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCaseCallServiceClass_ServiceTypes_ServiceTypeId",
                table: "ServiceCaseCallServiceClasses",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            // Re-add primary key constraints for the previous table configurations
            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceCaseCallServiceTypes",
                table: "ServiceCaseCallServiceClasses",
                columns: new[] { "ServiceCaseCallId", "ServiceTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeServices",
                table: "EmployeeServices",
                columns: new[] { "EmployeeId", "ServiceId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechnicianServices",
                table: "TechnicianServices",
                columns: new[] { "TechnicianId", "ServiceId" });
        }

    }
}
