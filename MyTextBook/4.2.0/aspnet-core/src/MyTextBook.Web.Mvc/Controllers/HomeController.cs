using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyTextBook.Controllers;
using MyTextBook.Applications.Orders;
using System.Threading.Tasks;
using MyTextBook.Web.Models.Orders;

namespace MyTextBook.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MyTextBookControllerBase
    {
        private readonly IOrderssAppService _orderAppService;      
        public HomeController(IOrderssAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }
        public async Task<ActionResult> Index()
        {
            
            var order = await _orderAppService.GetAllAsync("2");
            var model = new OrderListViewModel(order.Items);
            return View(model);
        }
	}
}
