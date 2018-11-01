using MyTextBook.Applications.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.ClientHome
{
    public class OrderDetaliViewModel
    {
        public OrderDetaliOutput orderDetaliOutput { get; set; }
        public OrderDetaliViewModel(OrderDetaliOutput _orderDetaliOutput)
        {
            orderDetaliOutput = _orderDetaliOutput;
        }
    }
}
