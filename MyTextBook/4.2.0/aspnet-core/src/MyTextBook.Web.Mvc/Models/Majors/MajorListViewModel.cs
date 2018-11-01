using MyTextBook.Applications.Majors.Dto;
using MyTextBook.Applications.TDepartments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.Majors
{
    public class MajorListViewModel
    {        
        public IReadOnlyList<MajorDtoOutput> MajorList { get; set; }
        public IReadOnlyList<TDepartmentDtoOutput> TDepartmentList { get; set; }
        public MajorListViewModel(IReadOnlyList<MajorDtoOutput> majorList, IReadOnlyList<TDepartmentDtoOutput> tDepartmentList)
        {
            MajorList = majorList;
            TDepartmentList = tDepartmentList;
        }
    }
}
