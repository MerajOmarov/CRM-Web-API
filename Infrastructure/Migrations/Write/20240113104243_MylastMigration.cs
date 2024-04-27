using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MylastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "All_products_Model_write",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OperatingSystem",
                table: "All_products_Model_write",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Prosessor",
                table: "All_products_Model_write",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Screen",
                table: "All_products_Model_write",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Videocard",
                table: "All_products_Model_write",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "All_products_Model_write");

            migrationBuilder.DropColumn(
                name: "OperatingSystem",
                table: "All_products_Model_write");

            migrationBuilder.DropColumn(
                name: "Prosessor",
                table: "All_products_Model_write");

            migrationBuilder.DropColumn(
                name: "Screen",
                table: "All_products_Model_write");

            migrationBuilder.DropColumn(
                name: "Videocard",
                table: "All_products_Model_write");
        }
    }
}
