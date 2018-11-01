using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyTextBook.Controllers;
using MyTextBook.Applications.Books.Dto;
using MyTextBook.Applications.Books;
using MyTextBook.Applications.BookTypes;
using X.PagedList;
using MyTextBook.Web.Models;
using Abp.Application.Services.Dto;
using MyTextBook.Web.Models.ClientHome;
using MyTextBook.Applications.Orders;
using MyTextBook.Applications.Orders.Dto;
using AutoMapper;
using MyTextBook.Applications.StudentClasses;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyTextBook.Applications.Courses;
using MyTextBook.Applications.Students;
using MyTextBook.Web.Models.Orders;
using OrderDetaliViewModel = MyTextBook.Web.Models.ClientHome.OrderDetaliViewModel;
using MyTextBook.Applications.StudentBookDetailses.Dto;
using MyTextBook.Applications.StudentBookDetailses;
using MyTextBook.Web.Models.Users;
using MyTextBook.Users;
using MyTextBook.Users.Dto;

namespace MyTextBook.Web.Mvc.Controllers
{
    public class ClientHomeController : MyTextBookControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IBooksAppService _bookAppService;
        private readonly IBookTypesAppService _bookTypeAppService;
        private readonly IOrderssAppService _orderAppService;
        private readonly IStudentClassesAppService _studentClassAppService;
        private readonly ICoursesAppService _courseAppService;
        private readonly IStudentsAppService _studentAppService;
        private readonly IStudentBookAppService _studentBookAppService;
        public ClientHomeController(IBooksAppService bookAppService, IBookTypesAppService bookTypeAppService, IOrderssAppService orderAppService, IStudentClassesAppService studentClassAppService, ICoursesAppService courseAppService, IStudentsAppService studentAppService, IStudentBookAppService studentBookAppService, IUserAppService userAppService)
        {
            _userAppService = userAppService;
            _bookAppService = bookAppService;
            _bookTypeAppService = bookTypeAppService;
            _orderAppService = orderAppService;
            _studentClassAppService = studentClassAppService;
            _courseAppService = courseAppService;
            _studentAppService = studentAppService;
            _studentBookAppService = studentBookAppService;
        }
        public async Task<ActionResult> Index(string SeachText, string currentFilter, string sortOrder, int? page)
        {
            ViewBag.NameSortParm = sortOrder;
            var pageSize = 12;//页大小
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
            BookPageInput pageInput = new BookPageInput()
            {
                pageIndex = pageNumber,
                pageMax = pageSize
            };
            BookSeachInput seachInput = new BookSeachInput()
            {
                SeachBookName = SeachText
            };
            BookOrderInput orderInput = new BookOrderInput()
            {
                OrderName = ViewBag.NameSortParm
            };
            var BookList = await _bookAppService.GetAllAsync(pageInput, seachInput, orderInput);

            var onePageOfBook = new StaticPagedList<BookDtoOutput>(BookList.Items, pageNumber, pageSize, BookList.TotalCount); //将分页结果放入ViewBag供View使用 ViewBag.OnePageOfTasks = onePageOfTasks; 
                                                                                                                               //pageNumber, pageSize, counts  页索引  页大小  总数
            ViewBag.OnePageOfTasks = onePageOfBook;
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateOrderViewModel model)
        {
            //int BookId,int StudentClassId,string CourseNumber,int Quantity,string Customer,string AcademicYear,string Semester,string Description
            // var orderDtoInput = Mapper.Map<OrderDtoInput>(model);
            OrderDtoInput orderDtoInput = new OrderDtoInput() {
                 BookId = model.BookId,
                 AcademicYear = model.AcademicYear,                
                 Customer = model.Customer,
                 Description = model.Description,
                 Quantity = model.Quantity,
                 Semester = model.Semester,
                 StudentClassId = model.StudentClassId,
                 CourseId = model.CourseId,   
                  
            };
             var order = await _orderAppService.CreateAsync(orderDtoInput);
            return View("Succe");
        }

        public async Task<ActionResult> DetailAsync(int bookId)
        {
            EntityDto entityDto = new EntityDto()
            {
                Id = bookId
            };
            var book = await _bookAppService.GetAsyncByIdAsync(entityDto);

            var studentClassList = await _studentClassAppService.GetAllAsync();
            ViewData["StudentClassList"] = new SelectList(studentClassList.Items, "Id", "StudentClassName");

            var courseList = await _courseAppService.GetAllAsync();
            ViewData["CourseList"] = new SelectList(courseList.Items, "Id", "CourseName");            

            var model = new DetailBookViewModel(book);
             return View("Detail", model);
            // return Json(ViewData["CourseList"]);
        }
        public async Task<ActionResult> DetaliUser()
        {
            var users = (await _userAppService.GetByIdUsersAsync());
            var model = new UserDetaliModelView(users);
            return View(model);
        }
        public async Task<IActionResult> MyOrderList()
        {
            EntityDto entityDto = new EntityDto() {
                Id = Convert.ToInt32(AbpSession.UserId)
            };
            var orderList = await _orderAppService.GetAllAsync(entityDto);
            var model = new OrderListViewModel(orderList.Items);
            return View(model);
        }

        public async Task<IActionResult> OrderDetali(int id)
        {
            EntityDto entityDto = new EntityDto()
            {
                Id = id
            };
            var orderDetali = await _orderAppService.GetAsyncByIdAsync(entityDto);
            var model = new OrderDetaliViewModel(orderDetali);
            return View(model);
        }

        public async Task<IActionResult> StudentBookDetali(string SeachText, string currentFilter, string AcademicYear, string Semester, string StudentClassId, string StudentNum, int? page)
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

        }

        [HttpPost]
        public async Task<JsonResult> InJson()
        {
            BookPageInput pageInput = new BookPageInput()
            {
                pageIndex = 1,
                pageMax = 3
            };
            BookSeachInput seachInput = new BookSeachInput()
            {
                SeachBookName = ""
            };
            BookOrderInput orderInput = new BookOrderInput()
            {
                OrderName = ""
            };
            var BookList = await _bookAppService.GetAllAsync(pageInput, seachInput, orderInput);
            return Json(BookList);
        }

        public async Task<IActionResult> TeacherUpdate(EditUserDtoInput editUserDtoInput)
        {

            var user = await _userAppService.TeacherUpdate(editUserDtoInput);
            var model = new UserDetaliModelView(user);
           
            return View("DetaliUser", model);
        }

    }
}