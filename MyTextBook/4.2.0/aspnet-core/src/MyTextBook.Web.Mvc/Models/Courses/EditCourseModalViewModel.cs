using MyTextBook.Applications.Courses.Dto;
using MyTextBook.Applications.CourseTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.Courses
{
    public class EditCourseModalViewModel
    {
        public IReadOnlyList<CourseTypeDtoOutput> CourseTypeList { get; set; }
        public CourseDtoOutput Course { get; set; }
        public EditCourseModalViewModel(CourseDtoOutput _course, IReadOnlyList<CourseTypeDtoOutput> _courseTypeList)
        {
            Course = _course;
            CourseTypeList = _courseTypeList;
        }     
    }
}
