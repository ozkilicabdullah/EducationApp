using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addedassignededucationstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComplate",
                table: "AssignedEducations");

            migrationBuilder.AddColumn<DateTime>(
                name: "ComplatedDate",
                table: "AssignedEducations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EducationStatus",
                table: "AssignedEducations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComplatedDate",
                table: "AssignedEducations");

            migrationBuilder.DropColumn(
                name: "EducationStatus",
                table: "AssignedEducations");

            migrationBuilder.AddColumn<bool>(
                name: "IsComplate",
                table: "AssignedEducations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
