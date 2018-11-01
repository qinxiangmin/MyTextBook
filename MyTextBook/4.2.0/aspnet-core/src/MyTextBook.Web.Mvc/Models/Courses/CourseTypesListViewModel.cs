using MyTextBook.Applications.CourseTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.Courses
{
    public class CourseTypesListViewModel
    {
        public IReadOnlyList<CourseTypeDtoOutput> CourseTypeList { get; set; }
        public CourseTypesListViewModel(IReadOnlyList<CourseTypeDtoOutput> courseTypeList)
        {
            CourseTypeList = courseTypeList;
        }
    }
}
