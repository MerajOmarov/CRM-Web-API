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
                name: "_product_CreatedTime",
                table: "All_cops_Model_read",
                newName: "_cop_product_CreatedTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_cop_product_CreatedTime",
                table: "All_cops_Model_read",
                newName: "_product_CreatedTime");
        }
    }
}
