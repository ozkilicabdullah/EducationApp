using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Repository.Migrations
{
    /// <inheritdoc />
    public partial class removerelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationContentQuestions_EducationContents_EducationContentId",
                table: "EducationContentQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EducationContentQuestions",
                table: "EducationContentQuestions");

            migrationBuilder.DropIndex(
                name: "IX_EducationContentQuestions_EducationContentId",
                table: "EducationContentQuestions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducationContentQuestions",
                table: "EducationContentQuestions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EducationContentQuestions_QuestionId",
                table: "EducationContentQuestions",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EducationContentQuestions",
                table: "EducationContentQuestions");

            migrationBuilder.DropIndex(
                name: "IX_EducationContentQuestions_QuestionId",
                table: "EducationContentQuestions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducationContentQuestions",
                table: "EducationContentQuestions",
                columns: new[] { "QuestionId", "EducationContentId" });

            migrationBuilder.CreateIndex(
                name: "IX_EducationContentQuestions_EducationContentId",
                table: "EducationContentQuestions",
                column: "EducationContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationContentQuestions_EducationContents_EducationContentId",
                table: "EducationContentQuestions",
                column: "EducationContentId",
                principalTable: "EducationContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
