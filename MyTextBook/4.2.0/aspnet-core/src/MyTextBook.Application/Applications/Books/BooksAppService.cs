using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyTextBook.Applications.Books.Dto;
using MyTextBook.Applications.BookTypes;
using MyTextBook.Applications.BookTypes.Dto;
using MyTextBook.Entitys.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextBook.Applications.Books
{
    public class BooksAppService : MyTextBookAppServiceBase, IBooksAppService
    {
        private readonly IRepository<Book> _bookRepository;//仓储
        public BooksAppService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<BookDtoOutput> CreateAsync(BookDtoInput entity)
        {
            Book book = new Book()
            {
                BookTitle = entity.BookTitle,
                BookDescription = entity.BookDescription,
                ISBN = entity.ISBN,
                BookAuthor = entity.BookAuthor,
                Awards = entity.Awards,
                BookPublisher = entity.BookPublisher,
                BookTypeId = entity.BookTypeId,
                PublicationDate = entity.PublicationDate,
                UnitPrice = entity.UnitPrice
            };
            var newBook = await _bookRepository.InsertAsync(book);           
            return new BookDtoOutput();
        }

        public async Task DeleteAsync(EntityDto entity)
        {
            var bookType = await _bookRepository.GetAsync(entity.Id);
            await _bookRepository.DeleteAsync(bookType);
        }

        public async Task<PagedResultDto<BookDtoOutput>> GetAllAsync(BookPageInput bookPageInput, BookSeachInput bookSeachInput, BookOrderInput bookOrderInput)
        {
            var bookList = await _bookRepository.GetAll().Include(p => p.BookType).ToListAsync();

            if (!string.IsNullOrEmpty(bookSeachInput.SeachBookName))
            {
                bookList = bookList.Where(p => p.BookTitle.Contains(bookSeachInput.SeachBookName)).ToList();
            }
            if (bookOrderInput.OrderName == "Desc")
            {
                bookList = bookList.OrderByDescending(p => p.BookTitle).ToList();
            }
            else
            {
                bookList = bookList.OrderBy(p => p.BookTitle).ToList();
            }
            var booksCount = bookList.Count();
            var taskList = bookList.Skip((bookPageInput.pageIndex - 1) * bookPageInput.pageMax).Take(bookPageInput.pageMax).ToList();
            return new PagedResultDto<BookDtoOutput>(booksCount, taskList.MapTo<List<BookDtoOutput>>()
                    );
        }

        public async Task<BookDtoOutput> GetAsyncByIdAsync(EntityDto entity)
        {
            var book = await _bookRepository.GetAll().Include(p => p.BookType)
                .FirstOrDefaultAsync(p => p.Id == entity.Id);
            
            var bookDtoOutput = Mapper.Map<BookDtoOutput>(book);
            return bookDtoOutput;
        }

        public async Task<BookDtoOutput> UpdateAsync(BookDtoInput entity)
        {
            Book book = new Book()
            {
                 Id = entity.Id,
                 BookDescription = entity.BookDescription,
                 BookTitle = entity.BookTitle,
                 Awards = entity.Awards,
                 BookAuthor = entity.BookAuthor,
                 BookPublisher = entity.BookPublisher,
                 ISBN = entity.ISBN,
                 PublicationDate = entity.PublicationDate,
                 UnitPrice = entity.UnitPrice,
                 BookTypeId = entity.BookTypeId                 
            };
            var updateBookTypes = await _bookRepository.UpdateAsync(book);
           
            var bookDtoOutput = Mapper.Map<BookDtoOutput>(book);
            return bookDtoOutput;
        }
    }
}
