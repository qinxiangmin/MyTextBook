using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTextBook.Applications.Courses.Dto
{
    public class CourseDtoInput:EntityDto
    {
        public const int MaxNameLength = 50;

        [Required]
        [StringLength(MaxNameLength)]
        public string CourseNumber { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public string CourseName { get; set; }

        public int CourseTypeId { get; set; }

    }
}
