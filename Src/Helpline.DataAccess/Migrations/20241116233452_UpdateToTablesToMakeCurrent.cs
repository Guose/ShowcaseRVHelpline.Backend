using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpline.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToTablesToMakeCurrent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedOn",
                table: "Users",
                newName: "ModifiedOn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Users",
                newName: "LastModifiedOn");
        }
    }
}
