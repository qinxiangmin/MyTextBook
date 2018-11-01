using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTextBook.Applications.StudentBookDetailses.Dto
{
    public class StudentBookDtoInput:EntityDto
    {
        public int BookId { get; set; }
       
        public List<int> StudentId { get; set; }
       
        public int CourseId { get; set; }      

        public decimal UnitPrice { get; set; }       

        public string AcademicYear { get; set; }

        public string Semester { get; set; }
       
        public int OrderId { get; set; }
    }
}
