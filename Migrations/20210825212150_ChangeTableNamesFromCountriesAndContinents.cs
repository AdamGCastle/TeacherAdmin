using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherAdmin.Migrations
{
    public partial class ChangeTableNamesFromCountriesAndContinents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Continents_StudentID",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Continents",
                table: "Continents");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "LessonBlogs");

            migrationBuilder.RenameTable(
                name: "Continents",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_StudentID",
                table: "LessonBlogs",
                newName: "IX_LessonBlogs_StudentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonBlogs",
                table: "LessonBlogs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonBlogs_Students_StudentID",
                table: "LessonBlogs",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonBlogs_Students_StudentID",
                table: "LessonBlogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonBlogs",
                table: "LessonBlogs");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Continents");

            migrationBuilder.RenameTable(
                name: "LessonBlogs",
                newName: "Countries");

            migrationBuilder.RenameIndex(
                name: "IX_LessonBlogs_StudentID",
                table: "Countries",
                newName: "IX_Countries_StudentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Continents",
                table: "Continents",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Continents_StudentID",
                table: "Countries",
                column: "StudentID",
                principalTable: "Continents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
