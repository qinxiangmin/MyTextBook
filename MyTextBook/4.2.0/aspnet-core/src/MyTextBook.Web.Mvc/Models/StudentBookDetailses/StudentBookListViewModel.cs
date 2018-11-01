using MyTextBook.Applications.StudentBookDetailses.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.StudentBookDetailses
{
    public class StudentBookListViewModel
    {
        public IReadOnlyList<StudentBookDtoOutput> StudentBookList { get; set; }
        public StudentBookListViewModel(IReadOnlyList<StudentBookDtoOutput> studentBookList)
        {
            StudentBookList = studentBookList;
        }
    }
}
