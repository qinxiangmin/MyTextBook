using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTextBook.Migrations
{
    public partial class inital71 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrders_AbpUsers_UserId1",
                table: "AppOrders");

            migrationBuilder.DropIndex(
                name: "IX_AppOrders_UserId1",
                table: "AppOrders");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AppOrders");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "AppOrders",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_UserId",
                table: "AppOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrders_AbpUsers_UserId",
                table: "AppOrders",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrders_AbpUsers_UserId",
                table: "AppOrders");

            migrationBuilder.DropIndex(
                name: "IX_AppOrders_UserId",
                table: "AppOrders");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AppOrders",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "AppOrders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_UserId1",
                table: "AppOrders",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrders_AbpUsers_UserId1",
                table: "AppOrders",
                column: "UserId1",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
