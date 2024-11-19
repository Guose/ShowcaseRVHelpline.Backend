using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpline.DataAccess.MigrationHelpers
{
    public class IndexHelper
    {
        private readonly MigrationBuilder migrationBuilder;

        public IndexHelper(MigrationBuilder migrationBuilder)
        {
            this.migrationBuilder = migrationBuilder;
        }

        public void HandleIndex(string table, string name, bool isDrop)
        {
            string indexName = $"IX_{table}_{name}";
            if (isDrop)
            {
                migrationBuilder.DropIndex(
                name: indexName,
                table: table);
            }
            else
            {
                migrationBuilder.CreateIndex(
                name: indexName,
                table: table,
                column: name);
            }
        }
    }
}
