using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherAdmin.Migrations
{
    public partial class AddAnnotationsAndCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Likes",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Students");
        }
    }
}
