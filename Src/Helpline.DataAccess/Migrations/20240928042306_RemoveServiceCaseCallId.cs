using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveServiceCaseCallId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Check if a foreign key exists for the column, and drop it
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCases_ServiceCaseCalls_ServiceCaseCallId",
                table: "ServiceCases");

            // Check if there is an index related to the column, and drop it
            migrationBuilder.DropIndex(
                name: "IX_ServiceCases_ServiceCaseCallId",
                table: "ServiceCases");

            // Drop the ServiceCaseCallId column
            migrationBuilder.DropColumn(
                name: "ServiceCaseCallId",
                table: "ServiceCases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // If you roll back this migration, add the column back
            migrationBuilder.AddColumn<int>(
                name: "ServiceCaseCallId",
                table: "ServiceCases",
                type: "int",
                nullable: true);

            // Optionally, restore the foreign key and index if needed
            migrationBuilder.CreateIndex(
                name: "IX_ServiceCases_ServiceCaseCallId",
                table: "ServiceCases",
                column: "ServiceCaseCallId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCases_ServiceCaseCalls_ServiceCaseCallId",
                table: "ServiceCases",
                column: "ServiceCaseCallId",
                principalTable: "ServiceCaseCalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
