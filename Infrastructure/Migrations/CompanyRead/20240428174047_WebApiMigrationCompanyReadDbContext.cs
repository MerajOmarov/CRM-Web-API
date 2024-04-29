using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations._company_DbContext_readMigrations
{
    /// <inheritdoc />
    public partial class WebApiMigrationCompanyReadDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "All_cops_Model_read");

            migrationBuilder.CreateTable(
                name: "ClientOrderProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDeedline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerPIN = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerSername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductBarcode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductVideocard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductOperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductScreen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductProsessor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrderProducts", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientOrderProducts");

            migrationBuilder.CreateTable(
                name: "All_cops_Model_read",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPIN = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerSername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDeedline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductBarcode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    ProductProsessor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductScreen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductVideocard = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_cops_Model_read", x => x.ID);
                });
        }
    }
}
