using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTextBook.Applications.Books.Dto;
using MyTextBook.Applications.StudentBookDetailses;
using MyTextBook.Applications.StudentBookDetailses.Dto;
using MyTextBook.Applications.StudentClasses;
using MyTextBook.Controllers;
using MyTextBook.Web.Models.StudentBookDetailses;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using X.PagedList;

namespace MyTextBook.Web.Mvc.Controllers
{
    public class StudentBookDetailsesController : MyTextBookControllerBase
    {
        private readonly IStudentClassesAppService _studentClassAppService;
        private readonly IStudentBookAppService _studentBookAppService;
        public StudentBookDetailsesController(IStudentBookAppService studentBookAppService, IStudentClassesAppService studentClassAppService)
        {
            _studentBookAppService = studentBookAppService;
            _studentClassAppService = studentClassAppService;

        }
        public async Task<IActionResult> Index(string SeachText, string currentFilter, int? page, string AcademicYear,string Semester,string StudentClassId,string StudentNum)
        {

           
            ViewBag.NameAcademicYear = AcademicYear;
            ViewBag.NameSemester = Semester;
            ViewBag.NameStudentClassId = StudentClassId;
            ViewBag.NameStudentNum = StudentNum;

            ViewBag.NameAcademicYear_value = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="--全部--"},
                new SelectListItem(){Value="2016",Text="2016年"},
                new SelectListItem(){Value="2017",Text="2017年"}
            };
            ViewBag.NameSemester_value = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="--全部--"},
                new SelectListItem(){Value="1",Text="春季学期"},
                new SelectListItem(){Value="2",Text="秋季学期"}
            };
            var studentClassList = await _studentClassAppService.GetAllAsync();

           
            ViewBag.StudentClass_value = new SelectList(studentClassList.Items, "Id", "StudentClassName");

            var pageSize = 5;//页大小
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
            StudentBookPageInput pageInput = new StudentBookPageInput()
            {
                pageIndex = pageNumber,
                pageMax = pageSize
            };
            StudentBookSeachInput seachInput = new StudentBookSeachInput()
            {
                 SeachBookName = SeachText,
                AcademicYear = AcademicYear,
                Semester = Semester,
                StudentClassId = StudentClassId,
                StudentNum = StudentNum

            };
            StudentBookOrderInput orderInput = new StudentBookOrderInput()
            {
                OrderName = "Desc"
            };
            var BookList = await _studentBookAppService.GetAllAsync(pageInput, seachInput, orderInput);

            var onePageOfBook = new StaticPagedList<StudentBookDtoOutput>(BookList.Items, pageNumber, pageSize, BookList.TotalCount); //将分页结果放入ViewBag供View使用 ViewBag.OnePageOfTasks = onePageOfTasks; 
            //pageNumber, pageSize, counts  页索引  页大小  总数         
            ViewBag.OnePageOfTasks = onePageOfBook;
            return View();

            //var studentBook = await _studentBookAppService.GetAllAsync();
            //var model = new StudentBookListViewModel(studentBook.Items);
            //return View(model);
         
        }

        public async Task<ActionResult> GetexelcAsync(string academicYear,string semester,string studentClassId,string studentNum)
        {
            StudentBookPageInput pageInput = new StudentBookPageInput()
            {
                pageIndex = 0,
                pageMax = 999
            };
            StudentBookSeachInput seachInput = new StudentBookSeachInput()
            {
                 AcademicYear = academicYear,
                 Semester = semester,
                 StudentClassId = studentClassId,
                 StudentNum = studentNum

            };
            StudentBookOrderInput orderInput = new StudentBookOrderInput()
            {
              
            };
            var books = await _studentBookAppService.GetAllAsync(pageInput, seachInput, orderInput);
           
            HSSFWorkbook wk = new HSSFWorkbook();
            //创建一个Sheet  
            ISheet sheet = wk.CreateSheet("工作1");
            //在第一行创建行  
            IRow row = null;
            ICell cell = null;
            row = sheet.CreateRow(0);
            string[] titleStr = {"班级","学号", "姓名", "课程", "课程类型", "教材名称","码详","实详","折扣" };
            for (int j = 0; j < titleStr.Length; j++)
            {
                cell = row.CreateCell(j);
                cell.SetCellValue(titleStr[j]);
            }
            int index = 0;
            foreach (var item in books.Items)
            {
                index++;
                row = sheet.CreateRow(index);
                cell = row.CreateCell(0);
                cell.SetCellValue(item.StudentStudentClassStudentClassName);
                cell = row.CreateCell(1);
                cell.SetCellValue(item.StudentStudentNum);
                cell = row.CreateCell(2);
                cell.SetCellValue(item.StudentStudentName);
                cell = row.CreateCell(3);
                cell.SetCellValue(item.CourseCourseName);
                cell = row.CreateCell(4);
                cell.SetCellValue(item.CourseCourseTypeCourseTypeName);
                cell = row.CreateCell(5);
                cell.SetCellValue(item.BookBookTitle);
                cell = row.CreateCell(6);
                cell.SetCellValue(Convert.ToDouble(item.BookUnitPrice));
                cell = row.CreateCell(7);
                cell.SetCellValue(Convert.ToDouble(item.UnitPrice));
                cell = row.CreateCell(8);
                cell.SetCellValue(Convert.ToInt32(item.UnitPrice/item.BookUnitPrice *100));

            }
            string strdate = DateTime.Now.ToString("yyyyMMddhhmmss");//获取当前时间  
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            wk.Write(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return File(ms, "application/vnd.ms-excel", strdate + "Excel.xls");
        }
    }
}