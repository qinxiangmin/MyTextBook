using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTextBook.Applications.Orders.Dto
{
    public class OrderDtoOutput:EntityDto
    {
        public const int MaxNameLength = 25;
        public const int MaxDescriptionLength = 256;

        [Required]
        public string CourseNumber { get; set; }

        [Required]
        public int Quantity { get; set; }

        [StringLength(MaxNameLength)]
        public string Customer { get; set; }

        public DateTime OrderDate { get; set; }

        public string AcademicYear { get; set; }

        public string Semester { get; set; }

        public string OrderState { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }

       // public int BookId { get; set; }
        public string BookBookTitle { get; set; }

       
        public string CourseCourseName { get; set; }

        [Required]
        public bool Confirmation { get; set; }

        public int StudentClassId { get; set; }
        public string StudentClassStudentClassName { get; set; }
    }
}
