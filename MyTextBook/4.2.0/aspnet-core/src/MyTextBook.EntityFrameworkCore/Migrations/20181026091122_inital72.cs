using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTextBook.Migrations
{
    public partial class inital72 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "AppOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_CourseId",
                table: "AppOrders",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrders_AppCourses_CourseId",
                table: "AppOrders",
                column: "CourseId",
                principalTable: "AppCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrders_AppCourses_CourseId",
                table: "AppOrders");

            migrationBuilder.DropIndex(
                name: "IX_AppOrders_CourseId",
                table: "AppOrders");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "AppOrders");
        }
    }
}
