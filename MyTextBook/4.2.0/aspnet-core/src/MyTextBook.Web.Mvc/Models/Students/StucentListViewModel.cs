using MyTextBook.Applications.StudentClasses.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.Students
{
    public class StucentListViewModel
    {
        
        public IReadOnlyList<StudentClassDtoOutput> StudentClassList { get; set; }
        public StucentListViewModel(IReadOnlyList<StudentClassDtoOutput> studentClassList)
        {          
            StudentClassList = studentClassList;
        }
    }
}
