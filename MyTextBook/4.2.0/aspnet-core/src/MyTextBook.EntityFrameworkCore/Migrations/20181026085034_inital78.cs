using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTextBook.Migrations
{
    public partial class inital78 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "AppStudentBookDetailses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppStudentBookDetailses_CourseId",
                table: "AppStudentBookDetailses",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppStudentBookDetailses_AppCourses_CourseId",
                table: "AppStudentBookDetailses",
                column: "CourseId",
                principalTable: "AppCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppStudentBookDetailses_AppCourses_CourseId",
                table: "AppStudentBookDetailses");

            migrationBuilder.DropIndex(
                name: "IX_AppStudentBookDetailses_CourseId",
                table: "AppStudentBookDetailses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "AppStudentBookDetailses");
        }
    }
}
