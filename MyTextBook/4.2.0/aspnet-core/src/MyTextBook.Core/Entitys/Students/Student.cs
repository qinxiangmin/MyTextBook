using Abp.Domain.Entities;
using MyTextBook.Entitys.StudentClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTextBook.Entitys.Students
{
    [Table("AppStudents")]
    public class Student : Entity, ISoftDelete
    {
        public const int MaxNameLength = 80;

        [Required]
        [StringLength(MaxNameLength)]
        public string StudentNum { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public string StudentName { get; set; }

        [Required]
        public string StudentSex { get; set; }

        public int StudentClassId { get; set; }
        public StudentClass StudentClass { get; set; }
        public bool IsDeleted { get ; set ; }
    }
}
