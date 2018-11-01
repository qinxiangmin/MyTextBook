using MyTextBook.Applications.BookTypes.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.BookTypes
{
    public class BookTyoeListViewModel
    {
        public IReadOnlyList<BookTypeDtoOutput> BookList { get; set; }
        public BookTyoeListViewModel(IReadOnlyList<BookTypeDtoOutput> booklist)
        {
            BookList = booklist;
        }

    }
}
