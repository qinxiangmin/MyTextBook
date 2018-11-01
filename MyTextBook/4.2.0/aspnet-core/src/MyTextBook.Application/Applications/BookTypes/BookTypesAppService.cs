using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using MyTextBook.Applications.BookTypes.Dto;
using MyTextBook.Entitys.BookTypes;

namespace MyTextBook.Applications.BookTypes
{
    public class BookTypesAppService : MyTextBookAppServiceBase, IBookTypesAppService
    {
        private readonly IRepository<BookType> _bookTypeRepository;//仓储
        public BookTypesAppService(IRepository<BookType> bookTypeRepository)
        {
            _bookTypeRepository = bookTypeRepository;
            
        }

        public async Task<BookTypeDtoOutput> CreateAsync(BookTypeDtoInput entity)
        {
            BookType bookType = new BookType() {
                 BookTypeName = entity.BookTypeName,
                 BookTypeDescription = entity.BookTypeDescription                 
            };
            var newBookType = await _bookTypeRepository.InsertAsync(bookType);

            var bookDtoOutput = Mapper.Map<BookTypeDtoOutput>(bookType);
            return bookDtoOutput;
        }

        public async Task DeleteAsync(EntityDto entity)
        {
            var bookType = await _bookTypeRepository.GetAsync(entity.Id);
            await _bookTypeRepository.DeleteAsync(bookType); 
        }

        public async Task<ListResultDto<BookTypeDtoOutput>> GetAllAsync()
        {
            var bookType = await _bookTypeRepository.GetAllListAsync();
           
            return new ListResultDto<BookTypeDtoOutput>(
                 ObjectMapper.Map<List<BookTypeDtoOutput>>(bookType)
                 );
        }

        public async Task<BookTypeDtoOutput> GetAsyncByIdAsync(EntityDto entity)
        {
            var bookType = await _bookTypeRepository.FirstOrDefaultAsync(entity.Id);

            var bookDtoOutput = Mapper.Map<BookTypeDtoOutput>(bookType);           
            return bookDtoOutput;
        }

        public async Task<BookTypeDtoOutput> UpdateAsync(BookTypeDtoInput entity)
        {
            BookType bookType = new BookType()
            {
                Id = entity.Id,
                BookTypeDescription = entity.BookTypeDescription,
                BookTypeName = entity.BookTypeName
            };
           
            var updateBookTypes = await _bookTypeRepository.UpdateAsync(bookType);           
            var bookDtoOutput = Mapper.Map<BookTypeDtoOutput>(updateBookTypes);
            return bookDtoOutput;
        }
    }
}
