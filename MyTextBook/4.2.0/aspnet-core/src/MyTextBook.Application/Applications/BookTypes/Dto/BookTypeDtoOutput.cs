using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTextBook.Applications.BookTypes.Dto
{
    public class BookTypeDtoOutput:EntityDto
    {
        public const int MaxNameLength = 80;
        public const int MaxDescriptionLength = 256;

        [Required]
        [StringLength(MaxNameLength)]
        public string BookTypeName { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string BookTypeDescription { get; set; }
    }
}
