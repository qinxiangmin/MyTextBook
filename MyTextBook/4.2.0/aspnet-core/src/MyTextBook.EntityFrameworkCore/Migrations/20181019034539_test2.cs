using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTextBook.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppAcademicYears",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcademicYearTitle = table.Column<string>(maxLength: 30, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAcademicYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppBookTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookTypeName = table.Column<int>(maxLength: 80, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBookTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppCourseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCourseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppStudentClassTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentClassId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStudentClassTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStudentClassTeachers_AppStudentClasses_StudentClassId",
                        column: x => x.StudentClassId,
                        principalTable: "AppStudentClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppStudents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentNum = table.Column<string>(maxLength: 80, nullable: false),
                    StudentName = table.Column<string>(maxLength: 80, nullable: false),
                    StudentSex = table.Column<string>(nullable: false),
                    StudentClassId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStudents_AppStudentClasses_StudentClassId",
                        column: x => x.StudentClassId,
                        principalTable: "AppStudentClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppBooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ISBN = table.Column<string>(maxLength: 80, nullable: true),
                    BookTitle = table.Column<string>(maxLength: 80, nullable: false),
                    BookDescription = table.Column<string>(maxLength: 256, nullable: true),
                    BookAuthor = table.Column<string>(maxLength: 80, nullable: true),
                    BookPublisher = table.Column<string>(maxLength: 80, nullable: true),
                    PublicationDate = table.Column<DateTime>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Awards = table.Column<string>(nullable: true),
                    BookTypeId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppBooks_AppBookTypes_BookTypeId",
                        column: x => x.BookTypeId,
                        principalTable: "AppBookTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseNumber = table.Column<string>(maxLength: 50, nullable: false),
                    CourseTypeId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCourses_AppCourseTypes_CourseTypeId",
                        column: x => x.CourseTypeId,
                        principalTable: "AppCourseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseNumber = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Customer = table.Column<string>(nullable: true),
                    Confirmation = table.Column<bool>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    AcademicYear = table.Column<string>(nullable: true),
                    Semester = table.Column<string>(nullable: true),
                    OrderState = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BookId = table.Column<int>(nullable: false),
                    StudentClassId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOrders_AppBooks_BookId",
                        column: x => x.BookId,
                        principalTable: "AppBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppOrders_AppStudentClasses_StudentClassId",
                        column: x => x.StudentClassId,
                        principalTable: "AppStudentClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppOrders_AbpUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppStudentBookDetailses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Discount = table.Column<string>(nullable: true),
                    AcademicYear = table.Column<string>(nullable: true),
                    Semester = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStudentBookDetailses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStudentBookDetailses_AppBooks_BookId",
                        column: x => x.BookId,
                        principalTable: "AppBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppStudentBookDetailses_AppStudents_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AppStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppTeacherBookDetailses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<int>(nullable: false),
                    Discount = table.Column<string>(nullable: true),
                    AcademicYear = table.Column<string>(nullable: true),
                    Semester = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTeacherBookDetailses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTeacherBookDetailses_AppBooks_BookId",
                        column: x => x.BookId,
                        principalTable: "AppBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppBooks_BookTypeId",
                table: "AppBooks",
                column: "BookTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCourses_CourseTypeId",
                table: "AppCourses",
                column: "CourseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_BookId",
                table: "AppOrders",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_StudentClassId",
                table: "AppOrders",
                column: "StudentClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_UserId1",
                table: "AppOrders",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AppStudentBookDetailses_BookId",
                table: "AppStudentBookDetailses",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_AppStudentBookDetailses_StudentId",
                table: "AppStudentBookDetailses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppStudentClassTeachers_StudentClassId",
                table: "AppStudentClassTeachers",
                column: "StudentClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppStudents_StudentClassId",
                table: "AppStudents",
                column: "StudentClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTeacherBookDetailses_BookId",
                table: "AppTeacherBookDetailses",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppAcademicYears");

            migrationBuilder.DropTable(
                name: "AppCourses");

            migrationBuilder.DropTable(
                name: "AppOrders");

            migrationBuilder.DropTable(
                name: "AppStudentBookDetailses");

            migrationBuilder.DropTable(
                name: "AppStudentClassTeachers");

            migrationBuilder.DropTable(
                name: "AppTeacherBookDetailses");

            migrationBuilder.DropTable(
                name: "AppCourseTypes");

            migrationBuilder.DropTable(
                name: "AppStudents");

            migrationBuilder.DropTable(
                name: "AppBooks");

            migrationBuilder.DropTable(
                name: "AppBookTypes");
        }
    }
}
