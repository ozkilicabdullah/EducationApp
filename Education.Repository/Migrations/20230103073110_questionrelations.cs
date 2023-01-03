using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Repository.Migrations
{
    /// <inheritdoc />
    public partial class questionrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_EducationContents_EducationContentId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_EducationContentId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "EducationContentId",
                table: "Questions");

            migrationBuilder.CreateTable(
                name: "EducationContentQuestions",
                columns: table => new
                {
                    EducationContentId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationContentQuestions", x => new { x.QuestionId, x.EducationContentId });
                    table.ForeignKey(
                        name: "FK_EducationContentQuestions_EducationContents_EducationContentId",
                        column: x => x.EducationContentId,
                        principalTable: "EducationContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationContentQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestion",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => new { x.ExamId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationContentQuestions_EducationContentId",
                table: "EducationContentQuestions",
                column: "EducationContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_QuestionId",
                table: "ExamQuestion",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationContentQuestions");

            migrationBuilder.DropTable(
                name: "ExamQuestion");

            migrationBuilder.AddColumn<int>(
                name: "EducationContentId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_EducationContentId",
                table: "Questions",
                column: "EducationContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_EducationContents_EducationContentId",
                table: "Questions",
                column: "EducationContentId",
                principalTable: "EducationContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
