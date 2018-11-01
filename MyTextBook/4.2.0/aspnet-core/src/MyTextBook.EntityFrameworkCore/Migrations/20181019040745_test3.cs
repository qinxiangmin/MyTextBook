using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTextBook.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "AppStudentClassTeachers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_AppStudentClassTeachers_UserId",
                table: "AppStudentClassTeachers",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppStudentClassTeachers_AbpUsers_UserId",
                table: "AppStudentClassTeachers",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppStudentClassTeachers_AbpUsers_UserId",
                table: "AppStudentClassTeachers");

            migrationBuilder.DropIndex(
                name: "IX_AppStudentClassTeachers_UserId",
                table: "AppStudentClassTeachers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppStudentClassTeachers");
        }
    }
}
