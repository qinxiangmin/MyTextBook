using MyTextBook.Applications.Majors.Dto;
using MyTextBook.Applications.Orders.Dto;
using MyTextBook.Applications.StudentClasses.Dto;
using MyTextBook.Applications.Students.Dto;
using MyTextBook.Applications.TDepartments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.Orders
{
    public class OrderDetaliViewModel
    {
        public OrderDetaliOutput orderDetaliOutput { get; set; }
      
        public IReadOnlyList<StudentDtoOutput> studenList { get; set; }
        public OrderDetaliViewModel(OrderDetaliOutput _orderDetaliOutput, IReadOnlyList<StudentDtoOutput> _studenList)
        {
            orderDetaliOutput = _orderDetaliOutput;            
            studenList = _studenList;
        }
    }
}
