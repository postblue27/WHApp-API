using Microsoft.EntityFrameworkCore.Migrations;

namespace WHApp_API.Migrations
{
    public partial class ChangedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RenterWarehouses_Renters_UserId",
                table: "RenterWarehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Owners_UserId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_UserId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_RenterWarehouses_UserId",
                table: "RenterWarehouses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RenterWarehouses");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Warehouses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RenterId",
                table: "RenterWarehouses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_OwnerId",
                table: "Warehouses",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RenterWarehouses_RenterId",
                table: "RenterWarehouses",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_RenterWarehouses_Renters_RenterId",
                table: "RenterWarehouses",
                column: "RenterId",
                principalTable: "Renters",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_RenterWarehouses_Renters_RenterId",
                table: "RenterWarehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Owners_OwnerId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_OwnerId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_RenterWarehouses_RenterId",
                table: "RenterWarehouses");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "RenterWarehouses");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Warehouses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RenterWarehouses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_UserId",
                table: "Warehouses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RenterWarehouses_UserId",
                table: "RenterWarehouses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RenterWarehouses_Renters_UserId",
                table: "RenterWarehouses",
                column: "UserId",
                principalTable: "Renters",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

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
