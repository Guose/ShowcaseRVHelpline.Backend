using Microsoft.EntityFrameworkCore.Migrations;

namespace Helpline.DataAccess.MigrationHelpers
{
    public class ColumnHelper
    {
        private readonly MigrationBuilder migrationBuilder;

        public ColumnHelper(MigrationBuilder migrationBuilder)
        {
            this.migrationBuilder = migrationBuilder;
        }

        public void AddNewColumns<T>(string table, string name, bool isNullable)
        {
            migrationBuilder.AddColumn<T>(name, table, nullable: isNullable);
        }

        public void PopulateNewColumns(string table, string name)
        {
            migrationBuilder.Sql($"UPDATE {table} SET {name} = NEWID()");
        }

        public void PopulateForeignKeyColumn(string table, string newCol, string associatedTable, string foreignKey, string primaryKey)
        {
            migrationBuilder.Sql(@$"
                UPDATE {table}
                SET {newCol} = {associatedTable}.{newCol}
                FROM {table}
                INNER JOIN {associatedTable} ON {table}.{foreignKey} = {associatedTable}.{primaryKey}");
        }

        public void DropOldColumns(string table, string keyColumn)
        {
            migrationBuilder.DropColumn(keyColumn, table);
        }

        public void RenameColumns(string table, string originalName, string newName)
        {
            migrationBuilder.RenameColumn(newName, table, originalName);
        }

        public void AlterColumnNullable<T>(string table, string column)
        {
            migrationBuilder.AlterColumn<T>(
                name: column,
                table: table,
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true
            );
        }
    }
}
