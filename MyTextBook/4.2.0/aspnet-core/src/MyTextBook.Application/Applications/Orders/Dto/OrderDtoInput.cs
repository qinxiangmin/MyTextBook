using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTextBook.Applications.Orders.Dto
{
    public class OrderDtoInput:EntityDto
    {
        public const int MaxNameLength = 25;
        public const int MaxDescriptionLength = 256;

       // [Required]
       // public string CourseNumber { get; set; }

        [Required]
        public int Quantity { get; set; }

        [StringLength(MaxNameLength)]
        public string Customer { get; set; }

     
        public string AcademicYear { get; set; }

        public string Semester { get; set; }
       
        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public int CourseId { get; set; }

        public int BookId { get; set; }
      
        public int StudentClassId { get; set; }
        
    }
}
