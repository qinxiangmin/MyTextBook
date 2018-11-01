using Abp.Domain.Entities;
using MyTextBook.Entitys.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTextBook.Entitys.TeacherBookDetailses
{
    [Table("AppTeacherBookDetailses")]
    public class TeacherBookDetails : Entity, ISoftDelete
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int UserId { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }

        public string Discount { get; set; }

        public string AcademicYear { get; set; }

        public string Semester { get; set; }

        public bool IsDeleted { get ; set ; }
    }
}
