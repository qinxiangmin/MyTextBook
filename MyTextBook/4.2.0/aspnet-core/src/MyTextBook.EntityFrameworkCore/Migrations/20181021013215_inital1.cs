using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTextBook.Migrations
{
    public partial class inital1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TDepartmentName",
                table: "AppTDepartments",
                maxLength: 56,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AppTDepartments",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "AppTDepartments");

            migrationBuilder.AlterColumn<string>(
                name: "TDepartmentName",
                table: "AppTDepartments",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 56);
        }
    }
}
