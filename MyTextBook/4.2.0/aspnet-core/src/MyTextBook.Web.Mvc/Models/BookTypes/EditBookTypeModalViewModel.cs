using MyTextBook.Applications.BookTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.BookTypes
{
    public class EditBookTypeModalViewModel
    {
        public BookTypeDtoOutput Book { get; set; }
        public EditBookTypeModalViewModel(BookTypeDtoOutput _book)
        {
            Book = _book;
        }
    }
}
