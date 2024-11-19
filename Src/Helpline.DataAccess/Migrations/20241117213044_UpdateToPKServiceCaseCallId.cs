using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToPKServiceCaseCallId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ServiceCases_ServiceCaseCalls_ServiceCaseCallId",
            //    table: "ServiceCases");

            //migrationBuilder.DropIndex(
            //    name: "IX_ServiceCases_ServiceCaseCallId",
            //    table: "ServiceCases");

            //migrationBuilder.DropColumn(
            //    name: "ServiceCaseCallId",
            //    table: "ServiceCases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceCaseCallId",
                table: "ServiceCases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCases_ServiceCaseCallId",
                table: "ServiceCases",
                column: "ServiceCaseCallId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCases_ServiceCaseCalls_ServiceCaseCallId",
                table: "ServiceCases",
                column: "ServiceCaseCallId",
                principalTable: "ServiceCaseCalls",
                principalColumn: "Id");
        }
    }
}
