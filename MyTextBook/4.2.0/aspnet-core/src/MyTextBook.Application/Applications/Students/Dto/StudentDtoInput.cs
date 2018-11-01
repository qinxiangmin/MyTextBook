using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTextBook.Applications.Students.Dto
{
    public class StudentDtoInput:EntityDto
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
       
    }
}
