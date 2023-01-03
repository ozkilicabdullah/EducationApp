using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Repository.Migrations
{
    /// <inheritdoc />
    public partial class assignedv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignedEducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false),
                    IsComplate = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedEducations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEducationContentHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EducationContentId = table.Column<int>(type: "int", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducationContentHistories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedEducations");

            migrationBuilder.DropTable(
                name: "UserEducationContentHistories");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "QuestionCategories",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ExamCategories",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EducationContents",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EducationCategories",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DepartmentUnits",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "Value");
        }
    }
}
