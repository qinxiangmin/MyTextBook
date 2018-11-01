
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using MyTextBook.Applications.Majors;
using MyTextBook.Applications.Orders;
using MyTextBook.Applications.StudentClasses;
using MyTextBook.Applications.Students;
using MyTextBook.Applications.TDepartments;
using MyTextBook.Controllers;
using MyTextBook.Web.Models.Orders;

namespace MyTextBook.Web.Mvc.Controllers
{
    public class OrdersController : MyTextBookControllerBase
    {
        private readonly IOrderssAppService _orderAppService;
        private readonly ITDepartmentsAppService _tDepartmentsAppService;
        private readonly IMajorsAppService _majorsAppService;
        private readonly IStudentClassesAppService _studentClassesAppService;
        private readonly IStudentsAppService _studentAppService;
        public OrdersController(IOrderssAppService orderAppService, ITDepartmentsAppService tDepartmentsAppService, IMajorsAppService majorsAppService, IStudentClassesAppService studentClassesAppService, IStudentsAppService studentAppService)
        {
            _orderAppService = orderAppService;
            _tDepartmentsAppService = tDepartmentsAppService;
            _majorsAppService = majorsAppService;
            _studentClassesAppService = studentClassesAppService;
            _studentAppService = studentAppService;
        }
        public async Task<IActionResult> Index()
        {
            var order = await _orderAppService.GetAllAsync("1");
            var model = new OrderListViewModel(order.Items);
            return View(model);     
           
        }

        public async Task<IActionResult> Details(int id)
        {
            // OrderDetaliViewModel
            EntityDto entityDto = new EntityDto() {
                Id = id
            };
            var orderDetali = await _orderAppService.GetAsyncByIdAsync(entityDto);
            
            EntityDto entityDto1 = new EntityDto()
            {
                Id = orderDetali.StudentClassId
            };
            var studentList = await _studentAppService.GetAllAsync(entityDto1);

            var model = new OrderDetaliViewModel(orderDetali, studentList.Items);
            return View(model);
            //return Json(model);
        }
    }
}