using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Permssions",
                table: "Users",
                newName: "Permissions");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Permissions",
                table: "Users",
                newName: "Permssions");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
