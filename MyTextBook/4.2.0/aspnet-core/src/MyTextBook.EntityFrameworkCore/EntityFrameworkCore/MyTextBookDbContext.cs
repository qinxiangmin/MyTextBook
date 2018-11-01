using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyTextBook.Authorization.Roles;
using MyTextBook.Authorization.Users;
using MyTextBook.MultiTenancy;
using MyTextBook.Entitys.StudentClasses;
using MyTextBook.Entitys.Majors;
using MyTextBook.Entitys.Department;
using MyTextBook.Entitys.AcademicYears;
using MyTextBook.Entitys.Books;
using MyTextBook.Entitys.BookTypes;
using MyTextBook.Entitys.Courses;
using MyTextBook.Entitys.CourseTypes;
using MyTextBook.Entitys.Order;
using MyTextBook.Entitys.StudentBookDetailses;
using MyTextBook.Entitys.StudentClassTeacheres;
using MyTextBook.Entitys.Students;
using MyTextBook.Entitys.TeacherBookDetailses;

namespace MyTextBook.EntityFrameworkCore
{
    public class MyTextBookDbContext : AbpZeroDbContext<Tenant, Role, User, MyTextBookDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<StudentClass> StudentClass { get; set; }
        public DbSet<Major> Major { get; set; }
        public DbSet<TDepartment> TDepartment { get; set; }
        public DbSet<AcademicYear> AcademicYear { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookType> BookType { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseType> CourseType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<StudentBookDetails> StudentBookDetails { get; set; }
        public DbSet<StudentClassTeacher> StudentClassTeacher { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<TeacherBookDetails> TeacherBookDetails { get; set; }     
        public MyTextBookDbContext(DbContextOptions<MyTextBookDbContext> options)
            : base(options)
        {
        }
    }
}
