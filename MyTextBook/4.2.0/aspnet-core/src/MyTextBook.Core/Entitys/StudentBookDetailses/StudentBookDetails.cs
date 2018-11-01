using Abp.Domain.Entities;
using MyTextBook.Entitys.Books;
using MyTextBook.Entitys.Courses;
using MyTextBook.Entitys.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTextBook.Entitys.StudentBookDetailses
{
    [Table("AppStudentBookDetailses")]
    public class StudentBookDetails : Entity, ISoftDelete
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

       
        public string AcademicYear { get; set; }

        public string Semester { get; set; }

        public bool IsDeleted { get ; set ; }
    }
}
