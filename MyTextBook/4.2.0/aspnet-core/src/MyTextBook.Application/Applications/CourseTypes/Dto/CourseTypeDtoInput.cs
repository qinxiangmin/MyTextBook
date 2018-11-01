using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTextBook.Applications.CourseTypes.Dto
{
    public class CourseTypeDtoInput:EntityDto
    {
        public const int MaxNameLength = 50;

        [Required]
        [StringLength(MaxNameLength)]
        public string CourseTypeName { get; set; }

        public string Description { get; set; }
    }
}
