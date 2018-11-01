using MyTextBook.Applications.Majors.Dto;
using MyTextBook.Applications.StudentClasses.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.StudentClasses
{
    public class StudentClassListViewModel
    {
        public IReadOnlyList<MajorDtoOutput> MajorList { get; set; }
        public IReadOnlyList<StudentClassDtoOutput> StudentClassList { get; set; }
        public StudentClassListViewModel(IReadOnlyList<MajorDtoOutput> majorList, IReadOnlyList<StudentClassDtoOutput> studentClassList)
        {
            MajorList = majorList;
            StudentClassList = studentClassList;
        }
    }
}
