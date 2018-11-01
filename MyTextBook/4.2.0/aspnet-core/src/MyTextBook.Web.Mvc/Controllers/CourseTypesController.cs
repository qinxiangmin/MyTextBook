using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using MyTextBook.Applications.CourseTypes;
using MyTextBook.Controllers;
using MyTextBook.Web.Models.CourseTypes;

namespace MyTextBook.Web.Mvc.Controllers
{
    public class CourseTypesController : MyTextBookControllerBase
    {
        private readonly ICourseTypesAppService _courseTypesAppService;
        public CourseTypesController(ICourseTypesAppService courseTypesAppService)
        {
            _courseTypesAppService = courseTypesAppService;
        }
        public async Task<IActionResult> Index()
        {
            var courseType = await _courseTypesAppService.GetAllAsync();
            var model = new CourseTypeListViewModel(courseType.Items);

            return View(model);
        }
        public async Task<IActionResult> EditCourseTypeModal(int courseTypeId)
        {
            EntityDto entityDto = new EntityDto()
            {
                Id = courseTypeId
            };
            var courseType = await _courseTypesAppService.GetAsyncByIdAsync(entityDto);
            var model = new EditCourseTypeModalViewModel(courseType);

            return View("_EditCourseTypeModal", model);
        }
    }
}