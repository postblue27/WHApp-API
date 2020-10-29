using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WHApp_API.Migrations
{
    public partial class ChangedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Owners_UserId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_UserId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Warehouses");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Warehouses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProductCode = table.Column<string>(nullable: true),
                    RenterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    ZoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneName = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.ZoneId);
                    table.ForeignKey(
                        name: "FK_Zones_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<string>(nullable: true),
                    DriverId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsInWarehouse",
                columns: table => new
                {
                    ProductInWarehouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ZoneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsInWarehouse", x => x.ProductInWarehouseId);
                    table.ForeignKey(
                        name: "FK_ProductsInWarehouse_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsInWarehouse_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsInWarehouse_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "ZoneId");
                });

            migrationBuilder.CreateTable(
                name: "ProductsForShipping",
                columns: table => new
                {
                    ProductShippingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Destination = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsForShipping", x => x.ProductShippingId);
                    table.ForeignKey(
                        name: "FK_ProductsForShipping_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId");
                    table.ForeignKey(
                        name: "FK_ProductsForShipping_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductForShipping",
                columns: table => new
                {
                    ProductForShippingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentDeadline = table.Column<DateTime>(nullable: false),
                    ProductInWarehouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductForShipping", x => x.ProductForShippingId);
                    table.ForeignKey(
                        name: "FK_ProductForShipping_ProductsInWarehouse_ProductInWarehouseId",
                        column: x => x.ProductInWarehouseId,
                        principalTable: "ProductsInWarehouse",
                        principalColumn: "ProductInWarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_OwnerId",
                table: "Warehouses",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DriverId",
                table: "Cars",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductForShipping_ProductInWarehouseId",
                table: "ProductForShipping",
                column: "ProductInWarehouseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_RenterId",
                table: "Products",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsForShipping_CarId",
                table: "ProductsForShipping",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsForShipping_ProductId",
                table: "ProductsForShipping",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInWarehouse_ProductId",
                table: "ProductsInWarehouse",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInWarehouse_WarehouseId",
                table: "ProductsInWarehouse",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInWarehouse_ZoneId",
                table: "ProductsInWarehouse",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_WarehouseId",
                table: "Zones",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Owners_OwnerId",
                table: "Warehouses",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Owners_OwnerId",
                table: "Warehouses");

            migrationBuilder.DropTable(
                name: "ProductForShipping");

            migrationBuilder.DropTable(
                name: "ProductsForShipping");

            migrationBuilder.DropTable(
                name: "ProductsInWarehouse");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_OwnerId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Warehouses");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Warehouses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_UserId",
                table: "Warehouses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Owners_UserId",
                table: "Warehouses",
                column: "UserId",
                principalTable: "Owners",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
