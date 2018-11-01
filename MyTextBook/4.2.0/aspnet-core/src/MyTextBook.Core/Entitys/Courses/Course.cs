using Abp.Domain.Entities;
using MyTextBook.Entitys.CourseTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTextBook.Entitys.Courses
{
    [Table("AppCourses")]
    public class Course : Entity, ISoftDelete
    {
        public const int MaxNameLength = 50;

        [Required]
        [StringLength(MaxNameLength)]
        public string CourseNumber { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public string CourseName { get; set; }

        public int CourseTypeId { get; set; }
        public CourseType CourseType { get; set; }

        public bool IsDeleted { get ; set ; }
    }
}
