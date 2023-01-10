using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Repository.Migrations
{
    /// <inheritdoc />
    public partial class educationTypeadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompulsoryEducation",
                table: "Educations");

            migrationBuilder.AddColumn<int>(
                name: "EducationType",
                table: "Educations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EducationType",
                table: "Educations");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompulsoryEducation",
                table: "Educations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
