using MyTextBook.Applications.CourseTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.CourseTypes
{
    public class CourseTypeListViewModel
    {
        public IReadOnlyList<CourseTypeDtoOutput> CourseList { get; set; }
        public CourseTypeListViewModel(IReadOnlyList<CourseTypeDtoOutput> courseList)
        {
            CourseList = courseList;
        }
    }
}
