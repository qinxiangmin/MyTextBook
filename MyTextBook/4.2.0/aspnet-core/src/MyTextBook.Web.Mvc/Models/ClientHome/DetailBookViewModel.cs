using MyTextBook.Applications.Books.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.ClientHome
{
    public class DetailBookViewModel
    {       
        public BookDtoOutput Book { get; set; }
        public DetailBookViewModel(BookDtoOutput _book)
        {
            Book = _book;           
        }
    }
}
