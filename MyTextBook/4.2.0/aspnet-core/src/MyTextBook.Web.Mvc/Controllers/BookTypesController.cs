using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using MyTextBook.Applications.BookTypes;
using MyTextBook.Applications.BookTypes.Dto;
using MyTextBook.Controllers;
using MyTextBook.Web.Models.BookTypes;

namespace MyTextBook.Web.Mvc.Controllers
{
    public class BookTypesController : MyTextBookControllerBase
    {
       
        private readonly IBookTypesAppService _bookTypeAppService;
        public BookTypesController(IBookTypesAppService bookTypeAppService)
        {
            _bookTypeAppService = bookTypeAppService;          
        }
        public async Task<IActionResult> Index()
        {
            var bookType = await _bookTypeAppService.GetAllAsync();
            var model = new BookTyoeListViewModel(bookType.Items);
           
            return View(model);
        }
        
        public async Task<IActionResult> EditBookTypeModal(int bookTypeId)
        {
            EntityDto entityDto = new EntityDto() {
                Id = bookTypeId
            };
            var bookType = await _bookTypeAppService.GetAsyncByIdAsync(entityDto);
            var model = new EditBookTypeModalViewModel(bookType);

            return View("_EditBookTypeModal", model);
        }
    }
}