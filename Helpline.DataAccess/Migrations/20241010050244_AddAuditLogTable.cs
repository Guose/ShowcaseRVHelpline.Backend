using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditLogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "EmployeeService",
            //    keyColumns: new[] { "EmployeeId", "ServiceId" },
            //    keyValues: new object[] { -1, 2 });

            //migrationBuilder.DeleteData(
            //    table: "EmployeeService",
            //    keyColumns: new[] { "EmployeeId", "ServiceId" },
            //    keyValues: new object[] { -1, 6 });

            //migrationBuilder.DeleteData(
            //    table: "KnowledgeBaseTags",
            //    keyColumns: new[] { "KnowledgeBaseId", "TagId" },
            //    keyValues: new object[] { -2, -5 });

            //migrationBuilder.DeleteData(
            //    table: "KnowledgeBaseTags",
            //    keyColumns: new[] { "KnowledgeBaseId", "TagId" },
            //    keyValues: new object[] { -2, -2 });

            //migrationBuilder.DeleteData(
            //    table: "KnowledgeBaseTags",
            //    keyColumns: new[] { "KnowledgeBaseId", "TagId" },
            //    keyValues: new object[] { -1, -3 });

            //migrationBuilder.DeleteData(
            //    table: "KnowledgeBaseTags",
            //    keyColumns: new[] { "KnowledgeBaseId", "TagId" },
            //    keyValues: new object[] { -1, -1 });

            //migrationBuilder.DeleteData(
            //    table: "ServiceCaseCallServiceTypes",
            //    keyColumns: new[] { "ServiceCaseCallId", "ServiceTypeId" },
            //    keyValues: new object[] { -2, 7 });

            //migrationBuilder.DeleteData(
            //    table: "ServiceCaseCallServiceTypes",
            //    keyColumns: new[] { "ServiceCaseCallId", "ServiceTypeId" },
            //    keyValues: new object[] { -2, 9 });

            //migrationBuilder.DeleteData(
            //    table: "ServiceCaseCallServiceTypes",
            //    keyColumns: new[] { "ServiceCaseCallId", "ServiceTypeId" },
            //    keyValues: new object[] { -1, 18 });

            //migrationBuilder.DeleteData(
            //    table: "ServiceCaseTags",
            //    keyColumns: new[] { "ServiceCaseId", "TagId" },
            //    keyValues: new object[] { -2, -3 });

            //migrationBuilder.DeleteData(
            //    table: "ServiceCaseTags",
            //    keyColumns: new[] { "ServiceCaseId", "TagId" },
            //    keyValues: new object[] { -2, -1 });

            //migrationBuilder.DeleteData(
            //    table: "ServiceCaseTags",
            //    keyColumns: new[] { "ServiceCaseId", "TagId" },
            //    keyValues: new object[] { -1, -5 });

            //migrationBuilder.DeleteData(
            //    table: "ServiceCaseTags",
            //    keyColumns: new[] { "ServiceCaseId", "TagId" },
            //    keyValues: new object[] { -1, -2 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 18, -2 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 20, -2 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 1, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 2, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 3, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 4, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 5, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 6, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 8, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 9, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 10, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 11, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 12, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 13, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 14, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 15, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 17, -1 });

            //migrationBuilder.DeleteData(
            //    table: "TechnicianServices",
            //    keyColumns: new[] { "ServiceId", "TechnicianId" },
            //    keyValues: new object[] { 19, -1 });

            //migrationBuilder.DeleteData(
            //    table: "VehicleRvRenters",
            //    keyColumns: new[] { "RenterId", "VehicleId" },
            //    keyValues: new object[] { -3, -2 });

            //migrationBuilder.DeleteData(
            //    table: "VehicleRvRenters",
            //    keyColumns: new[] { "RenterId", "VehicleId" },
            //    keyValues: new object[] { -2, -3 });

            //migrationBuilder.DeleteData(
            //    table: "VehicleRvRenters",
            //    keyColumns: new[] { "RenterId", "VehicleId" },
            //    keyValues: new object[] { -2, -2 });

            //migrationBuilder.DeleteData(
            //    table: "VehicleRvRenters",
            //    keyColumns: new[] { "RenterId", "VehicleId" },
            //    keyValues: new object[] { -1, -1 });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCode = table.Column<int>(type: "int", nullable: false),
                    StatusMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.InsertData(
                table: "EmployeeService",
                columns: new[] { "EmployeeId", "ServiceId" },
                values: new object[,]
                {
                    { -1, 2 },
                    { -1, 6 }
                });

            migrationBuilder.InsertData(
                table: "KnowledgeBaseTags",
                columns: new[] { "KnowledgeBaseId", "TagId" },
                values: new object[,]
                {
                    { -2, -5 },
                    { -2, -2 },
                    { -1, -3 },
                    { -1, -1 }
                });

            migrationBuilder.InsertData(
                table: "ServiceCaseCallServiceTypes",
                columns: new[] { "ServiceCaseCallId", "ServiceTypeId" },
                values: new object[,]
                {
                    { -2, 7 },
                    { -2, 9 },
                    { -1, 18 }
                });

            migrationBuilder.InsertData(
                table: "ServiceCaseTags",
                columns: new[] { "ServiceCaseId", "TagId" },
                values: new object[,]
                {
                    { -2, -3 },
                    { -2, -1 },
                    { -1, -5 },
                    { -1, -2 }
                });

            migrationBuilder.InsertData(
                table: "TechnicianServices",
                columns: new[] { "ServiceId", "TechnicianId" },
                values: new object[,]
                {
                    { 18, -2 },
                    { 20, -2 },
                    { 1, -1 },
                    { 2, -1 },
                    { 3, -1 },
                    { 4, -1 },
                    { 5, -1 },
                    { 6, -1 },
                    { 8, -1 },
                    { 9, -1 },
                    { 10, -1 },
                    { 11, -1 },
                    { 12, -1 },
                    { 13, -1 },
                    { 14, -1 },
                    { 15, -1 },
                    { 17, -1 },
                    { 19, -1 }
                });

            migrationBuilder.InsertData(
                table: "VehicleRvRenters",
                columns: new[] { "RenterId", "VehicleId" },
                values: new object[,]
                {
                    { -3, -2 },
                    { -2, -3 },
                    { -2, -2 },
                    { -1, -1 }
                });
        }
    }
}
