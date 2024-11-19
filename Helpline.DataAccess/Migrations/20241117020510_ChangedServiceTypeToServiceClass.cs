using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedServiceTypeToServiceClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Rename table: ServiceTypes to ServiceClasses
            migrationBuilder.RenameTable(
                name: "ServiceTypes",
                newName: "ServiceClasses");

            // Rename table: ServiceCaseCallServiceTypes to ServiceCaseCallServiceClasses
            migrationBuilder.RenameTable(
                name: "ServiceCaseCallServiceTypes",
                newName: "ServiceCaseCallServiceClasses");

            // Rename column: ServiceTypeId to ServiceClassId in ServiceCaseCallServiceClasses
            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "ServiceCaseCallServiceClasses",
                newName: "ServiceClassId");

            // Rename index related to ServiceTypeId
            migrationBuilder.RenameIndex(
                name: "IX_ServiceCaseCallServiceTypes_ServiceTypeId",
                table: "ServiceCaseCallServiceClasses",
                newName: "IX_ServiceCaseCallServiceClasses_ServiceClassId");

            // Update Foreign BedType: ServiceCaseCallServiceClasses.ServiceClassId references ServiceClasses.Id
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCaseCallServiceTypes_ServiceTypes_ServiceTypeId",
                table: "ServiceCaseCallServiceClasses");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCaseCallServiceClasses_ServiceClasses_ServiceClassId",
                table: "ServiceCaseCallServiceClasses",
                column: "ServiceClassId",
                principalTable: "ServiceClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Rename table: ServiceClasses back to ServiceTypes
            migrationBuilder.RenameTable(
                name: "ServiceClasses",
                newName: "ServiceTypes");

            // Rename table: ServiceCaseCallServiceClasses back to ServiceCaseCallServiceTypes
            migrationBuilder.RenameTable(
                name: "ServiceCaseCallServiceClasses",
                newName: "ServiceCaseCallServiceTypes");

            // Rename column: ServiceClassId back to ServiceTypeId in ServiceCaseCallServiceTypes
            migrationBuilder.RenameColumn(
                name: "ServiceClassId",
                table: "ServiceCaseCallServiceTypes",
                newName: "ServiceTypeId");

            // Rename index related to ServiceClassId
            migrationBuilder.RenameIndex(
                name: "IX_ServiceCaseCallServiceClasses_ServiceClassId",
                table: "ServiceCaseCallServiceTypes",
                newName: "IX_ServiceCaseCallServiceTypes_ServiceTypeId");

            // Update Foreign BedType: ServiceCaseCallServiceTypes.ServiceTypeId references ServiceTypes.Id
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCaseCallServiceClasses_ServiceClasses_ServiceClassId",
                table: "ServiceCaseCallServiceTypes");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCaseCallServiceTypes_ServiceTypes_ServiceTypeId",
                table: "ServiceCaseCallServiceTypes",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
