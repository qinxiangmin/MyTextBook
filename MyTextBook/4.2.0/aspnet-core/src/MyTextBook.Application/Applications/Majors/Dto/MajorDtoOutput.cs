using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTextBook.Applications.Majors.Dto
{
    public class MajorDtoOutput:EntityDto
    {
        public const int MaxNameLength = 256;

        [Required]
        [StringLength(MaxNameLength)]
        public string MajorName { get; set; }

        [StringLength(MaxNameLength)]
        public string LeaderName { get; set; }

        public int TDepartmentId { get; set; }

        public string TDepartmentTDepartmentName { get; set; }
    }
}
