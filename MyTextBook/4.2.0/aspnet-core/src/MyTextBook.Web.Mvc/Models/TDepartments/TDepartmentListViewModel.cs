using MyTextBook.Applications.TDepartments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.TDepartments
{
    public class TDepartmentListViewModel
    {
        public IReadOnlyList<TDepartmentDtoOutput> TDepartmentList { get; set; }
        public TDepartmentListViewModel(IReadOnlyList<TDepartmentDtoOutput> tDepartmentList)
        {
            TDepartmentList = tDepartmentList;
        }
    }
}
