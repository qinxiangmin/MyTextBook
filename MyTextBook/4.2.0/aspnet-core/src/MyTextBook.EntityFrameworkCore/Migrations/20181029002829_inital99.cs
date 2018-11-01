using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTextBook.Migrations
{
    public partial class inital99 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "AppStudentBookDetailses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discount",
                table: "AppStudentBookDetailses",
                nullable: true);
        }
    }
}
