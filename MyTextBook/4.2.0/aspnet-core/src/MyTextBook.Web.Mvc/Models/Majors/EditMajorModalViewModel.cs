using MyTextBook.Applications.CourseTypes.Dto;
using MyTextBook.Applications.Majors.Dto;
using MyTextBook.Applications.TDepartments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.Majors
{
    public class EditMajorModalViewModel
    {
      
        public MajorDtoOutput Major { get; set; }
        public IReadOnlyList<TDepartmentDtoOutput> TDepartmentList { get; set; }
        public EditMajorModalViewModel(MajorDtoOutput _major, IReadOnlyList<TDepartmentDtoOutput> tDepartmentList)
        {
            Major = _major;
            TDepartmentList = tDepartmentList;
        }
    }
}
