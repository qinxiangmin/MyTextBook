using MyTextBook.Applications.CourseTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.CourseTypes
{
    public class EditCourseTypeModalViewModel
    {
        public CourseTypeDtoOutput CourseType { get; set; }
        public EditCourseTypeModalViewModel(CourseTypeDtoOutput _courseType)
        {
            CourseType = _courseType;
        }
    }
}
