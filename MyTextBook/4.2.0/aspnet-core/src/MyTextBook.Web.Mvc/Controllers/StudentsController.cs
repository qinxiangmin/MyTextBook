using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTextBook.Applications.StudentClasses;
using MyTextBook.Applications.Students;
using MyTextBook.Applications.Students.Dto;
using MyTextBook.Controllers;
using MyTextBook.Web.Models.Students;
using X.PagedList;

namespace MyTextBook.Web.Mvc.Controllers
{
    public class StudentsController : MyTextBookControllerBase
    {
        private readonly StudentsAppService _studentAppService;
        private readonly IStudentClassesAppService _studentClassesAppService;
        public StudentsController(StudentsAppService studentAppService, IStudentClassesAppService studentClassesAppService)
        {
            _studentAppService = studentAppService;
            _studentClassesAppService = studentClassesAppService;
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
            StudentPageInput pageInput = new StudentPageInput()
            {
                pageIndex = pageNumber,
                pageMax = pageSize
            };
            StudentSeachInput seachInput = new StudentSeachInput()
            {
                SeachBookName = SeachText
            };
            StudentOrderInput orderInput = new StudentOrderInput()
            {
                OrderName = ViewBag.NameSortParm
            };
            var StudentList = await _studentAppService.GetAllAsync(pageInput, seachInput, orderInput);

            var onePageOfBook = new StaticPagedList<StudentDtoOutput>(StudentList.Items, pageNumber, pageSize, StudentList.TotalCount); //将分页结果放入ViewBag供View使用 ViewBag.OnePageOfTasks = onePageOfTasks; 
            //pageNumber, pageSize, counts  页索引  页大小  总数


            var studentClassList = await _studentClassesAppService.GetAllAsync();
            var model = new StucentListViewModel(studentClassList.Items);

            ViewBag.OnePageOfTasks = onePageOfBook;

            return View(model);
        }
    }
}