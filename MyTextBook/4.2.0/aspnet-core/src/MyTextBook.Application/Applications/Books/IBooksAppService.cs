using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTextBook.Applications.Books.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTextBook.Applications.Books
{
    public interface IBooksAppService : IApplicationService
    {
        Task<PagedResultDto<BookDtoOutput>> GetAllAsync(BookPageInput bookPageInput, BookSeachInput bookSeachInput, BookOrderInput bookOrderInput);

        Task<BookDtoOutput> GetAsyncByIdAsync(EntityDto entity);

        Task<BookDtoOutput> CreateAsync(BookDtoInput entity);

        Task DeleteAsync(EntityDto entity);

        Task<BookDtoOutput> UpdateAsync(BookDtoInput entity);
    }
}
