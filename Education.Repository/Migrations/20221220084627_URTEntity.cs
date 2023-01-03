using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Repository.Migrations
{
    public partial class URTEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "UserRefreshTokens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserRefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "UserRefreshTokens",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserRefreshTokens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UserRefreshTokens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserRefreshTokens");
        }
    }
}
