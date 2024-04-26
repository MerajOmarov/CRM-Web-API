using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations._company_DbContext_readMigrations
{
    /// <inheritdoc />
    public partial class ThelastestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "All_cops_Model_read",
                newName: "ProductCreatedTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductCreatedTime",
                table: "All_cops_Model_read",
                newName: "CreatedTime");
        }
    }
}
