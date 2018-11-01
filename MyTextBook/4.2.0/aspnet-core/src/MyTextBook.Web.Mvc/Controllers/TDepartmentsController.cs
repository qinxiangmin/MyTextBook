using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using MyTextBook.Applications.TDepartments;
using MyTextBook.Controllers;
using MyTextBook.Web.Models.TDepartments;

namespace MyTextBook.Web.Mvc.Controllers
{
    public class TDepartmentsController : MyTextBookControllerBase
    {
        private readonly ITDepartmentsAppService _TDepartmentsAppService;       
        public TDepartmentsController(ITDepartmentsAppService TDepartmentsAppService)
        {
            _TDepartmentsAppService = TDepartmentsAppService;
            
        }
        public async Task<IActionResult> Index()
        {
            var tDepartment = await _TDepartmentsAppService.GetAllAsync();
            var model = new TDepartmentListViewModel(tDepartment.Items);
            return View(model);
        }

        public async Task<IActionResult> EditTDepartmentModalAsync(int tDepartmentId)
        {
            EntityDto entityDto = new EntityDto() {
                Id = tDepartmentId
            };
            var tDepartment = await _TDepartmentsAppService.GetAsyncByIdAsync(entityDto);
            var model = new EditTDepartmentModalViewModel(tDepartment);
            return View("_EditTDepartmentModalViewModel", model);
        }
    }
}