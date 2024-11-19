using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpline.DataAccess.MigrationHelpers
{
    public class KeysHelper
    {
        private readonly MigrationBuilder migrationBuilder;

        public KeysHelper(MigrationBuilder migrationBuilder)
        {
            this.migrationBuilder = migrationBuilder;
        }

        public void DropForeignKeys(string tableName, string associatedTable, string column)
        {
            migrationBuilder.DropForeignKey($"FK_{tableName}_{associatedTable}_{column}", tableName);
        }

        public void DropPrimaryKeys(string table)
        {
            migrationBuilder.DropPrimaryKey($"PK_{table}", table);
        }

        public void AddPrimaryKeys(string table, string column)
        {
            migrationBuilder.AddPrimaryKey($"PK_{table}", table, column);
        }

        public void AddForeignKeys(string tableName, string column, string associatedTable, string associatedColumn)
        {
            migrationBuilder.AddForeignKey(
                name: $"FK_{tableName}_{associatedTable}_{column}",
                table: tableName,
                column: column,
                principalTable: associatedTable,
                principalColumn: associatedColumn);
        }
    }
}
