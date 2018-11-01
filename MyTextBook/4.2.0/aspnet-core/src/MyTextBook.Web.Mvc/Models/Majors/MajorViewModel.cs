using MyTextBook.Applications.Majors.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.Majors
{
    public class MajorViewModel
    {
        public IReadOnlyList<MajorDtoOutput> MajorList { get; set; }       
        public MajorViewModel(IReadOnlyList<MajorDtoOutput> majorList)
        {
            MajorList = majorList;
           
        }
    }
}
