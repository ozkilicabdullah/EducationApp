using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Repository.Migrations
{
    /// <inheritdoc />
    public partial class adduserexamtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "UserExamResults");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserExamResults",
                newName: "UserExamId");

            migrationBuilder.CreateTable(
                name: "UserExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExams", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EducationCategoryId",
                table: "Educations",
                column: "EducationCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_EducationCategories_EducationCategoryId",
                table: "Educations",
                column: "EducationCategoryId",
                principalTable: "EducationCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_EducationCategories_EducationCategoryId",
                table: "Educations");

            migrationBuilder.DropTable(
                name: "UserExams");

            migrationBuilder.DropIndex(
                name: "IX_Educations_EducationCategoryId",
                table: "Educations");

            migrationBuilder.RenameColumn(
                name: "UserExamId",
                table: "UserExamResults",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "UserExamResults",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
