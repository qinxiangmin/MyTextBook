using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTextBook.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppTDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TDepartmentName = table.Column<string>(maxLength: 256, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppMajors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MajorName = table.Column<string>(maxLength: 256, nullable: false),
                    LeaderName = table.Column<string>(maxLength: 256, nullable: true),
                    TDepartmentId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMajors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppMajors_AppTDepartments_TDepartmentId",
                        column: x => x.TDepartmentId,
                        principalTable: "AppTDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppStudentClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GradeName = table.Column<string>(maxLength: 25, nullable: false),
                    StudentClassName = table.Column<string>(maxLength: 25, nullable: true),
                    MajorId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStudentClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStudentClasses_AppMajors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "AppMajors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppMajors_TDepartmentId",
                table: "AppMajors",
                column: "TDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppStudentClasses_MajorId",
                table: "AppStudentClasses",
                column: "MajorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppStudentClasses");

            migrationBuilder.DropTable(
                name: "AppMajors");

            migrationBuilder.DropTable(
                name: "AppTDepartments");
        }
    }
}
