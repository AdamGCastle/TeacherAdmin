using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherAdmin.Migrations
{
    public partial class AddStudentIDToLessonBlogClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonBlogs_Students_StudentID",
                table: "LessonBlogs");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "LessonBlogs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonBlogs_Students_StudentID",
                table: "LessonBlogs",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonBlogs_Students_StudentID",
                table: "LessonBlogs");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "LessonBlogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_LessonBlogs_Students_StudentID",
                table: "LessonBlogs",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
