using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTextBook.Applications.StudentClasses.Dto
{
    public class StudentClassDtoOutput:EntityDto
    {
        public const int MaxNameLength = 25;

        [Required]
        [StringLength(MaxNameLength)]
        public string GradeName { get; set; }
        [StringLength(MaxNameLength)]
        public string StudentClassName { get; set; }

        public int MajorId { get; set; }

        public string MajorMajorName { get; set; }
    }
}
