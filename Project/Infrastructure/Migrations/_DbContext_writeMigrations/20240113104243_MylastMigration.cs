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
                name: "_product_Company",
                table: "All_products_Model_write",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_product_OperatingSystem",
                table: "All_products_Model_write",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_product_Prosessor",
                table: "All_products_Model_write",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_product_Screen",
                table: "All_products_Model_write",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_product_Videocard",
                table: "All_products_Model_write",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_product_Company",
                table: "All_products_Model_write");

            migrationBuilder.DropColumn(
                name: "_product_OperatingSystem",
                table: "All_products_Model_write");

            migrationBuilder.DropColumn(
                name: "_product_Prosessor",
                table: "All_products_Model_write");

            migrationBuilder.DropColumn(
                name: "_product_Screen",
                table: "All_products_Model_write");

            migrationBuilder.DropColumn(
                name: "_product_Videocard",
                table: "All_products_Model_write");
        }
    }
}
