using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTextBook.Applications.StudentClasses.Dto
{
    public class StudentClassDto:EntityDto
    {
        public const int MaxNameLength = 25;

        [Required]
        [StringLength(MaxNameLength)]
        public string GradeName { get; set; }
        [StringLength(MaxNameLength)]
        public string StudentClassName { get; set; }

        public int MajorId { get; set; }
            
    }
}
