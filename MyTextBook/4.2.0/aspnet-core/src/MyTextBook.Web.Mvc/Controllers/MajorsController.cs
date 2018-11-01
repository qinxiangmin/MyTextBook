using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using MyTextBook.Applications.Majors;
using MyTextBook.Applications.TDepartments;
using MyTextBook.Controllers;
using MyTextBook.Web.Models.CourseTypes;
using MyTextBook.Web.Models.Majors;

namespace MyTextBook.Web.Mvc.Controllers
{
    public class MajorsController : MyTextBookControllerBase
    {
        private readonly IMajorsAppService _majorAppService;
        private readonly ITDepartmentsAppService _tDepartmentsAppService;
        public MajorsController(IMajorsAppService majorAppService, ITDepartmentsAppService tDepartmentsAppService)
        {
            _majorAppService = majorAppService;
            _tDepartmentsAppService = tDepartmentsAppService;
        }
        public async Task<IActionResult> Index()
        {
            var major = await _majorAppService.GetAllAsync();
            var tDepartment = await _tDepartmentsAppService.GetAllAsync();


            var model = new MajorListViewModel(major.Items, tDepartment.Items);

            return View(model);
        }

        public async Task<IActionResult> GetMajorId(int tDepartmentId)
        {
            EntityDto entityDto = new EntityDto() {
                 Id = tDepartmentId,
            };
            var major = await _majorAppService.GetAllByTDepartmentIdAsync(entityDto);
            return Json(major);
        }

        public async Task<IActionResult> EditMajorModal(int majorId)
        {
            // EditMajorModalViewModel
            EntityDto entityDto = new EntityDto()
            {
                Id = majorId
            };
            var major = await _majorAppService.GetAsyncByIdAsync(entityDto);
            var tDeparmentList = await _tDepartmentsAppService.GetAllAsync();

            var model = new EditMajorModalViewModel(major, tDeparmentList.Items);

            return View("_EditMajorModal", model);
        }
    }
}