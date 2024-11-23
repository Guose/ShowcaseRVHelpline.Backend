using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OutboxMessageTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAwning",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasCDPlayer",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasDVDPlayer",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasExteriorShower",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasFireExtingusher",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasFireplace",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasFurnace",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasGenerator",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasInteriorShower",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasMicrowave",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasNavigation",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasPropane",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasRange",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasRearVisionCamera",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasRefrigerator",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasRoofAC",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasSlideout",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasSnowChains",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasTV",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasWaterHeater",
                table: "CustomerVehicles");

            migrationBuilder.DropColumn(
                name: "HasiPodDocking",
                table: "CustomerVehicles");

            //migrationBuilder.RenameColumn(
            //    name: "Quantity",
            //    table: "UserTokens",
            //    newName: "Value");

            migrationBuilder.AddColumn<string>(
                name: "FeatureDetails",
                table: "CustomerVehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OutboxMessageConsumers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessageConsumers", x => new { x.Id, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccuredOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutboxMessageConsumers");

            migrationBuilder.DropTable(
                name: "OutboxMessages");

            migrationBuilder.DropColumn(
                name: "FeatureDetails",
                table: "CustomerVehicles");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "UserTokens",
                newName: "Quantity");

            migrationBuilder.AddColumn<bool>(
                name: "HasAwning",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasCDPlayer",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasDVDPlayer",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasExteriorShower",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasFireExtingusher",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasFireplace",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasFurnace",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasGenerator",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasInteriorShower",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasMicrowave",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasNavigation",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPropane",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRange",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRearVisionCamera",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRefrigerator",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRoofAC",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSlideout",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSnowChains",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasTV",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasWaterHeater",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasiPodDocking",
                table: "CustomerVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
