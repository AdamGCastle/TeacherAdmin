using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherAdmin.Migrations
{
    public partial class AddVocabAndNextLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NextLessonIdeas",
                table: "LessonBlogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vocab",
                table: "LessonBlogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextLessonIdeas",
                table: "LessonBlogs");

            migrationBuilder.DropColumn(
                name: "Vocab",
                table: "LessonBlogs");
        }
    }
}
