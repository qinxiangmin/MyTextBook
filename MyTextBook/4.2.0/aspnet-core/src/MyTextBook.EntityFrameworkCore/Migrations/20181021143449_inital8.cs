using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTextBook.Migrations
{
    public partial class inital8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeadPortrait",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkNumber",
                table: "AbpUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadPortrait",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "WorkNumber",
                table: "AbpUsers");
        }
    }
}
