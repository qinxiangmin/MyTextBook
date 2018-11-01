using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using MyTextBook.Applications.Books;
using MyTextBook.Applications.Books.Dto;
using MyTextBook.Applications.BookTypes;
using MyTextBook.Controllers;
using MyTextBook.Web.Models.Books;
using MyTextBook.Web.Models.BookTypes;
using X.PagedList;
using X.PagedList.Mvc.Core;
namespace MyTextBook.Web.Mvc.Controllers
{
    public class BooksController : MyTextBookControllerBase
    {
        private readonly IBooksAppService _bookAppService;
        private readonly IBookTypesAppService _bookTypeAppService;
        public BooksController(IBooksAppService bookAppService, IBookTypesAppService bookTypeAppService)
        {
            _bookAppService = bookAppService;
            _bookTypeAppService = bookTypeAppService;
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


            var bookTypeList = await _bookTypeAppService.GetAllAsync();
            var model = new BookTyoeListViewModel(bookTypeList.Items);

            ViewBag.OnePageOfTasks = onePageOfBook;

            return View(model);
        }

        public async Task<IActionResult> EditBookModalAsync(int bookId)
        {
            EntityDto entityDto = new EntityDto()
            {
                Id = bookId
            };
            var book = await _bookAppService.GetAsyncByIdAsync(entityDto);
            var bookTypeList = await _bookTypeAppService.GetAllAsync();

            var model = new EditBookModalViewModel(book,bookTypeList.Items);
            
            return View("_EditBookModal", model);          
        }
    }
}