using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTextBook.Applications.StudentBookDetailses.Dto
{
    public class StudentBookDtoOutput
    {
        public const int MaxNameLength = 25;
        [StringLength(MaxNameLength)]
        public string StudentStudentClassStudentClassName { get; set; }

        [Required]
        [StringLength(80)]
        public string StudentStudentNum { get; set; }

        [Required]
        [StringLength(80)]
        public string StudentStudentName { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseCourseName { get; set; }

        [Required]
        [StringLength(80)]
        public string BookBookTitle { get; set; }

        [Required]
        [StringLength(80)]
        public string CourseCourseTypeCourseTypeName { get; set; }

        public string AcademicYear { get; set; }

        public string Semester { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal BookUnitPrice { get; set; }
    }
}
