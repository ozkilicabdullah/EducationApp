using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Repository.Migrations
{
    /// <inheritdoc />
    public partial class userexamupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "UserExamQuestionAnswers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserExamQuestionAnswers",
                newName: "UserExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserExamId",
                table: "UserExamQuestionAnswers",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "UserExamQuestionAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
