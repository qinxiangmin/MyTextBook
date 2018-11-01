using Abp.Domain.Entities;
using MyTextBook.Entitys.Courses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTextBook.Entitys.CourseTypes
{
    [Table("AppCourseTypes")]
    public class CourseType : Entity, ISoftDelete
    {
        public const int MaxNameLength = 50;

        [Required]
        [StringLength(MaxNameLength)]
        public string CourseTypeName { get; set; }

        public string Description { get; set; }

        public List<Course> Course { get; set; }

        public bool IsDeleted { get; set ; }
    }
}
