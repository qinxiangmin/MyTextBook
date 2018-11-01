using MyTextBook.Applications.TDepartments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.TDepartments
{
    public class EditTDepartmentModalViewModel
    {
        public TDepartmentDtoOutput TDepartment { get; set; }
        public EditTDepartmentModalViewModel(TDepartmentDtoOutput _tDepartment)
        {
            TDepartment = _tDepartment;
        }
    }
}
