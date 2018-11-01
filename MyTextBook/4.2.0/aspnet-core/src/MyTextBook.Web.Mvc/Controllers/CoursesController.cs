using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using MyTextBook.Applications.Courses;
using MyTextBook.Applications.Courses.Dto;
using MyTextBook.Applications.CourseTypes;
using MyTextBook.Controllers;
using MyTextBook.Web.Models.Courses;
using X.PagedList;

namespace MyTextBook.Web.Mvc.Controllers
{
    public class CoursesController : MyTextBookControllerBase
    {
        private readonly ICoursesAppService _courseAppService;
        private readonly ICourseTypesAppService _courseTypeAppService;      
        public CoursesController(ICoursesAppService courseAppService, ICourseTypesAppService courseTypesAppService)
        {
            _courseAppService = courseAppService;
            _courseTypeAppService = courseTypesAppService;
        }
        public async Task<IActionResult> Index(string SeachText, string currentFilter, string sortOrder, int? page)
        {
            ViewBag.NameSortParm = sortOrder;
            var pageSize = 2;//页大小
            if (SeachText != null)
            {
                page = 1;
            }
            else
            {
                SeachText = currentFilter;
            }
            var pageNumber = page ?? 1;//第几页
            ViewBag.CurrentFilter = SeachText;
            CoursePageInput pageInput = new CoursePageInput()
            {
                pageIndex = pageNumber,
                pageMax = pageSize
            };
            CourseSeachInput seachInput = new CourseSeachInput()
            {
                SeachBookName = SeachText
            };
            CourseOrderInput orderInput = new CourseOrderInput()
            {
                OrderName = ViewBag.NameSortParm
            };
            var CourseList = await _courseAppService.GetAllAsync(pageInput, seachInput, orderInput);

            var onePageOfCourse = new StaticPagedList<CourseDtoOutput>(CourseList.Items, pageNumber, pageSize, CourseList.TotalCount); //将分页结果放入ViewBag供View使用 ViewBag.OnePageOfTasks = onePageOfTasks; 
            //pageNumber, pageSize, counts  页索引  页大小  总数


            var courseTypeList = await _courseTypeAppService.GetAllAsync();
            var model = new CourseTypesListViewModel(courseTypeList.Items);

            ViewBag.OnePageOfTasks = onePageOfCourse;

            return View(model);
        }
        public async Task<IActionResult> EditCourseModal(int courseId)
        {
            EntityDto entityDto = new EntityDto()
            {
                Id = courseId
            };
            var course = await _courseAppService.GetAsyncByIdAsync(entityDto);
            var courseTypeList = await _courseTypeAppService.GetAllAsync();

            var model = new EditCourseModalViewModel(course, courseTypeList.Items);

            return View("_EditCourseModal", model);
        }
    }
}