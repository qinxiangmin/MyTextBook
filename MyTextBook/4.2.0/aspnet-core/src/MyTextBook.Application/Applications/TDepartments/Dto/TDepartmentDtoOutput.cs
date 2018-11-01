using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTextBook.Applications.TDepartments.Dto
{
    public class TDepartmentDtoOutput : EntityDto
    {
        public const int MaxNameLength = 56;
        public const int MaxDescriptionLength = 256;

        [Required]
        [StringLength(MaxNameLength)]
        public string TDepartmentName { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
