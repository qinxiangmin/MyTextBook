using MyTextBook.Applications.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.Orders
{
    public class OrderListViewModel
    {
        public IReadOnlyList<OrderDtoOutput> _orderList { get; set; }
        public OrderListViewModel(IReadOnlyList<OrderDtoOutput> orderList)
        {
            _orderList = orderList;
        }      
    }
}
