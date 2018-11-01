using Abp.Domain.Entities;
using MyTextBook.Entitys.Majors;
using MyTextBook.Entitys.StudentClassTeacheres;
using MyTextBook.Entitys.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTextBook.Entitys.StudentClasses
{
    [Table("AppStudentClasses")]
    public class StudentClass : Entity, ISoftDelete
    {
        public const int MaxNameLength = 25;

        [Required]
        [StringLength(MaxNameLength)]
        public string GradeName { get; set; }
        [StringLength(MaxNameLength)]
        public string StudentClassName { get; set; }

        public int MajorId { get; set; }
        public Major Major { get; set; }

 
        public List<Student> Student { get; set; }

        public bool IsDeleted { get ; set ; }
    }
}
