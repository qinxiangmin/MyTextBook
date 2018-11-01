using MyTextBook.Applications.Books.Dto;
using MyTextBook.Applications.BookTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.Books
{
    public class EditBookModalViewModel
    {
        public IReadOnlyList<BookTypeDtoOutput> BookTypeList { get; set; }
        public BookDtoOutput Book { get; set; }
        public EditBookModalViewModel(BookDtoOutput _book, IReadOnlyList<BookTypeDtoOutput> _BookTypeList)
        {
            Book = _book;
            BookTypeList = _BookTypeList;
        }
    }
}
