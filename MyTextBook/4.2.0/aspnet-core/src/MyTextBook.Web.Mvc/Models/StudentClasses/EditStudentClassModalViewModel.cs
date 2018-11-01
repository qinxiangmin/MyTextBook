using MyTextBook.Applications.Majors.Dto;
using MyTextBook.Applications.StudentClasses.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.StudentClasses
{
    public class EditStudentClassModalViewModel
    {
        public StudentClassDtoOutput StudentClassList { get; set; }
        public IReadOnlyList<MajorDtoOutput> Major { get; set; }
        public EditStudentClassModalViewModel(IReadOnlyList<MajorDtoOutput> _major, StudentClassDtoOutput _studentClassList)
        {
            Major = _major;
            StudentClassList = _studentClassList;
        }
    }
}
