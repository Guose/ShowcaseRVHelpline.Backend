using System;
using Helpline.DataAccess.MigrationHelpers;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIDsDataTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var columnHelper = new ColumnHelper(migrationBuilder);
            var keysHelper = new KeysHelper(migrationBuilder);
            var indexHelper = new IndexHelper(migrationBuilder);

            /////////// STEP #1 ///////////
            // Drop Foreign Keys first
            keysHelper.DropForeignKeys("RVRentals", "CustomerVehicles", "VehicleId");
            keysHelper.DropForeignKeys("Customers", "Subscriptions", "SubscriptionId");
            keysHelper.DropForeignKeys("ServiceCases", "CustomerVehicles", "CustomerVehicleId");
            keysHelper.DropForeignKeys("VehicleRvRenters", "CustomerVehicles", "VehicleId");
            keysHelper.DropForeignKeys("ServiceCaseTags", "ServiceCases", "ServiceCaseId");
            keysHelper.DropForeignKeys("ServiceCaseCalls", "ServiceCases", "ServiceCaseId");

            /////////// STEP #2 ///////////
            // Drop Primary Keys
            keysHelper.DropPrimaryKeys("Subscriptions");
            keysHelper.DropPrimaryKeys("CustomerVehicles");
            keysHelper.DropPrimaryKeys("RVRentals");
            keysHelper.DropPrimaryKeys("ServiceCases");
            keysHelper.DropPrimaryKeys("VehicleRvRenters");
            keysHelper.DropPrimaryKeys("ServiceCaseTags");

            /////////// STEP #3 ///////////
            // Drop Indexes
            indexHelper.HandleIndex("Customers", "SubscriptionId", true);
            indexHelper.HandleIndex("VehicleRvRenters", "VehicleId", true);
            indexHelper.HandleIndex("RVRentals", "VehicleId", true);
            indexHelper.HandleIndex("ServiceCases", "CustomerVehicleId", true);
            indexHelper.HandleIndex("ServiceCaseCalls", "ServiceCaseId", true);

            /////////// STEP #4 ///////////
            // Add new Guid Columns Primary tables
            columnHelper.AddNewColumns<Guid>("Subscriptions", "NewSubscriptionId", true);
            columnHelper.AddNewColumns<Guid>("CustomerVehicles", "NewVehicleId", true);
            columnHelper.AddNewColumns<Guid>("RVRentals", "NewRentalId", true);
            columnHelper.AddNewColumns<Guid>("ServiceCases", "NewServiceCaseId", true);

            // Add new Guid Columns Foreign tables
            columnHelper.AddNewColumns<Guid>("Checkouts", "NewRentalId", true);
            columnHelper.AddNewColumns<Guid>("Returns", "NewRentalId", true);
            columnHelper.AddNewColumns<Guid>("RVRentals", "NewVehicleId", true);
            columnHelper.AddNewColumns<Guid>("Customers", "NewSubscriptionId", true);
            columnHelper.AddNewColumns<Guid>("ServiceCases", "NewVehicleId", true);
            columnHelper.AddNewColumns<Guid>("VehicleRvRenters", "NewVehicleId", true);
            columnHelper.AddNewColumns<Guid>("ServiceCaseTags", "NewServiceCaseId", true);
            columnHelper.AddNewColumns<Guid>("ServiceCaseCalls", "NewServiceCaseId", true);

            /////////// STEP #5 ///////////
            // Populate new PK Id value
            columnHelper.PopulateNewColumns("Subscriptions", "NewSubscriptionId");
            columnHelper.PopulateNewColumns("CustomerVehicles", "NewVehicleId");
            columnHelper.PopulateNewColumns("RVRentals", "NewRentalId");
            columnHelper.PopulateNewColumns("ServiceCases", "NewServiceCaseId");

            // Populate new FK Id value
            columnHelper.PopulateForeignKeyColumn("Checkouts", "NewRentalId", "RVRentals", "RentalId", "Id");
            columnHelper.PopulateForeignKeyColumn("Returns", "NewRentalId", "RVRentals", "RentalId", "Id");
            columnHelper.PopulateForeignKeyColumn("RVRentals", "NewVehicleId", "CustomerVehicles", "VehicleId", "Id");
            columnHelper.PopulateForeignKeyColumn("Customers", "NewSubscriptionId", "Subscriptions", "SubscriptionId", "Id");
            columnHelper.PopulateForeignKeyColumn("ServiceCases", "NewVehicleId", "CustomerVehicles", "CustomerVehicleId", "Id");
            columnHelper.PopulateForeignKeyColumn("VehicleRvRenters", "NewVehicleId", "CustomerVehicles", "VehicleId", "Id");
            columnHelper.PopulateForeignKeyColumn("ServiceCaseTags", "NewServiceCaseId", "ServiceCases", "ServiceCaseId", "Id");
            columnHelper.PopulateForeignKeyColumn("ServiceCaseCalls", "NewServiceCaseId", "ServiceCases", "ServiceCaseId", "Id");

            /////////// STEP #6 ///////////
            // Drop old PK Id column
            columnHelper.DropOldColumns("Subscriptions", "Id");
            columnHelper.DropOldColumns("CustomerVehicles", "Id");
            columnHelper.DropOldColumns("RVRentals", "Id");
            columnHelper.DropOldColumns("ServiceCases", "Id");

            // Drop old FK Id column
            columnHelper.DropOldColumns("Customers", "SubscriptionId");
            columnHelper.DropOldColumns("VehicleRvRenters", "VehicleId");
            columnHelper.DropOldColumns("Checkouts", "RentalId");
            columnHelper.DropOldColumns("Returns", "RentalId");
            columnHelper.DropOldColumns("RVRentals", "VehicleId");
            columnHelper.DropOldColumns("ServiceCases", "CustomerVehicleId");
            columnHelper.DropOldColumns("ServiceCaseTags", "ServiceCaseId");
            columnHelper.DropOldColumns("ServiceCaseCalls", "ServiceCaseId");

            /////////// STEP #7 ///////////
            // Rename new Columns to original name
            columnHelper.RenameColumns("Subscriptions", "Id", "NewSubscriptionId");
            columnHelper.RenameColumns("CustomerVehicles", "Id", "NewVehicleId");
            columnHelper.RenameColumns("RVRentals", "Id", "NewRentalId");
            columnHelper.RenameColumns("ServiceCases", "Id", "NewServiceCaseId");
            columnHelper.RenameColumns("Checkouts", "RentalId", "NewRentalId");
            columnHelper.RenameColumns("Returns", "RentalId", "NewRentalId");
            columnHelper.RenameColumns("RVRentals", "VehicleId", "NewVehicleId");
            columnHelper.RenameColumns("Customers", "SubscriptionId", "NewSubscriptionId");
            columnHelper.RenameColumns("ServiceCases", "CustomerVehicleId", "NewVehicleId");
            columnHelper.RenameColumns("VehicleRvRenters", "VehicleId", "NewVehicleId");
            columnHelper.RenameColumns("ServiceCaseTags", "ServiceCaseId", "NewServiceCaseId");
            columnHelper.RenameColumns("ServiceCaseCalls", "ServiceCaseId", "NewServiceCaseId");

            /////////// STEP #8 ///////////

            // Alter the column to be non-nullable
            columnHelper.AlterColumnNullable<Guid>("Subscriptions", "Id");
            columnHelper.AlterColumnNullable<Guid>("CustomerVehicles", "Id");
            columnHelper.AlterColumnNullable<Guid>("RVRentals", "Id");
            columnHelper.AlterColumnNullable<Guid>("ServiceCases", "Id");
            columnHelper.AlterColumnNullable<Guid>("VehicleRvRenters", "VehicleId");
            columnHelper.AlterColumnNullable<int>("VehicleRvRenters", "RenterId");
            columnHelper.AlterColumnNullable<Guid>("ServiceCaseTags", "ServiceCaseId");
            columnHelper.AlterColumnNullable<int>("ServiceCaseTags", "TagId");

            // Add Primary Keys back
            keysHelper.AddPrimaryKeys("Subscriptions", "Id");
            keysHelper.AddPrimaryKeys("CustomerVehicles", "Id");
            keysHelper.AddPrimaryKeys("RVRentals", "Id");
            keysHelper.AddPrimaryKeys("ServiceCases", "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleRvRenters",
                table: "VehicleRvRenters",
                columns: ["VehicleId", "RenterId"]);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceCaseTags",
                table: "ServiceCaseTags",
                columns: ["ServiceCaseId", "TagId"]);

            /////////// STEP #9 ///////////
            // Re-Create Indexes
            indexHelper.HandleIndex("Customers", "SubscriptionId", false);
            indexHelper.HandleIndex("VehicleRvRenters", "VehicleId", false);
            indexHelper.HandleIndex("RVRentals", "VehicleId", false);
            indexHelper.HandleIndex("ServiceCases", "CustomerVehicleId", false);
            indexHelper.HandleIndex("ServiceCaseCalls", "ServiceCaseId", false);

            /////////// STEP #10 ///////////
            // Add Foreign Keys back
            keysHelper.AddForeignKeys("Checkouts", "RentalId", "RVRentals", "Id");
            keysHelper.AddForeignKeys("Returns", "RentalId", "RVRentals", "Id");
            keysHelper.AddForeignKeys("RVRentals", "VehicleId", "CustomerVehicles", "Id");
            keysHelper.AddForeignKeys("Customers", "SubscriptionId", "Subscriptions", "Id");
            keysHelper.AddForeignKeys("ServiceCases", "CustomerVehicleId", "CustomerVehicles", "Id");
            keysHelper.AddForeignKeys("VehicleRvRenters", "VehicleId", "CustomerVehicles", "Id");
            keysHelper.AddForeignKeys("ServiceCaseTags", "ServiceCaseId", "ServiceCases", "Id");
            keysHelper.AddForeignKeys("ServiceCaseCalls", "ServiceCaseId", "ServiceCases", "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "VehicleRvRenters",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceCaseId",
                table: "ServiceCaseTags",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerVehicleId",
                table: "ServiceCases",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ServiceCases",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceCaseId",
                table: "ServiceCaseCalls",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "RVRentals",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RVRentals",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "RentalId",
                table: "Returns",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CustomerVehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "RentalId",
                table: "Checkouts",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
