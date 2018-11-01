using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using MyTextBook.Applications.Majors;
using MyTextBook.Applications.StudentClasses;
using MyTextBook.Applications.StudentClasses.Dto;
using MyTextBook.Controllers;
using MyTextBook.Web.Models.Majors;
using MyTextBook.Web.Models.StudentClasses;
using X.PagedList;

namespace MyTextBook.Web.Mvc.Controllers
{
    public class StudentClassesController : MyTextBookControllerBase
    {
        private readonly IStudentClassesAppService _studentClassesAppService;
        private readonly IMajorsAppService _majorsAppService;
        public StudentClassesController(IStudentClassesAppService studentClassesAppService, IMajorsAppService majorsAppService)
        {
            _studentClassesAppService = studentClassesAppService;
            _majorsAppService = majorsAppService;
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
            StudentClassPageInput pageInput = new StudentClassPageInput()
            {
                pageIndex = pageNumber,
                pageMax = pageSize
            };
            StudentClassSeach seachInput = new StudentClassSeach()
            {
                SeachBookName = SeachText
            };
            StudentClassOrderInput orderInput = new StudentClassOrderInput()
            {
                OrderName = ViewBag.NameSortParm
            };
            var StudentClassList = await _studentClassesAppService.GetAllAsync(pageInput, seachInput, orderInput);

            var onePageOfBook = new StaticPagedList<StudentClassDtoOutput>(StudentClassList.Items, pageNumber, pageSize, StudentClassList.TotalCount); //将分页结果放入ViewBag供View使用 ViewBag.OnePageOfTasks = onePageOfTasks; 
            //pageNumber, pageSize, counts  页索引  页大小  总数


            var majorsList = await _majorsAppService.GetAllAsync();
            var model = new MajorViewModel(majorsList.Items);

            ViewBag.OnePageOfTasks = onePageOfBook;

            return View(model);
        }

        public async Task<IActionResult> EditStudentClassModal(int studentClassId)
        {
            EntityDto entityDto = new EntityDto()
            {
                Id = studentClassId
            };
            var studentClasses = await _studentClassesAppService.GetAsyncByIdAsync(entityDto);
            var majorList = await _majorsAppService.GetAllAsync();

            var model = new EditStudentClassModalViewModel(majorList.Items, studentClasses);

            return View("_EditStudentClassModal", model);
        }
    }
}