using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Repository.Migrations
{
    public partial class examrelaiton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_ExamCategories_ExamCategoryId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ExamCategoryId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ExamCategoryId",
                table: "Exams");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ExcamCategoryId",
                table: "Exams",
                column: "ExcamCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_ExamCategories_ExcamCategoryId",
                table: "Exams",
                column: "ExcamCategoryId",
                principalTable: "ExamCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_ExamCategories_ExcamCategoryId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ExcamCategoryId",
                table: "Exams");

            migrationBuilder.AddColumn<int>(
                name: "ExamCategoryId",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ExamCategoryId",
                table: "Exams",
                column: "ExamCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_ExamCategories_ExamCategoryId",
                table: "Exams",
                column: "ExamCategoryId",
                principalTable: "ExamCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
