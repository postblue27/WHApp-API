using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WHApp_API.Migrations
{
    public partial class UserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Renters",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Renters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Renters",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Owners",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Owners",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Owners",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Owners");
        }
    }
}
