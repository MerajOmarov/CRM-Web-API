using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations._company_DbContext_readMigrations
{
    /// <inheritdoc />
    public partial class MylastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "_cop_product_Company",
                table: "All_cops_Model_read",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_cop_product_OperatingSystem",
                table: "All_cops_Model_read",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_cop_product_Prosessor",
                table: "All_cops_Model_read",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_cop_product_Screen",
                table: "All_cops_Model_read",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "_cop_product_Videocard",
                table: "All_cops_Model_read",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "_product_CreatedTime",
                table: "All_cops_Model_read",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_cop_product_Company",
                table: "All_cops_Model_read");

            migrationBuilder.DropColumn(
                name: "_cop_product_OperatingSystem",
                table: "All_cops_Model_read");

            migrationBuilder.DropColumn(
                name: "_cop_product_Prosessor",
                table: "All_cops_Model_read");

            migrationBuilder.DropColumn(
                name: "_cop_product_Screen",
                table: "All_cops_Model_read");

            migrationBuilder.DropColumn(
                name: "_cop_product_Videocard",
                table: "All_cops_Model_read");

            migrationBuilder.DropColumn(
                name: "_product_CreatedTime",
                table: "All_cops_Model_read");
        }
    }
}
