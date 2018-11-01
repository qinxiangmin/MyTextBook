using Abp.Domain.Entities;
using MyTextBook.Authorization.Users;
using MyTextBook.Entitys.StudentClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTextBook.Entitys.StudentClassTeacheres
{
    [Table("AppStudentClassTeachers")]
    public class StudentClassTeacher : Entity, ISoftDelete
    {
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        //public int StudentClassId { get; set; }
        //[ForeignKey(nameof(StudentClassId))]
        //public StudentClass StudentClass { get; set; }

        public bool IsDeleted { get ; set ; }
    }
}
