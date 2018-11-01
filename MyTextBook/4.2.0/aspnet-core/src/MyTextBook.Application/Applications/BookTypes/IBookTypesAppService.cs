using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTextBook.Applications.BookTypes.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTextBook.Applications.BookTypes
{
    public interface IBookTypesAppService: IApplicationService
    {
        Task<ListResultDto<BookTypeDtoOutput>> GetAllAsync();

        Task<BookTypeDtoOutput> GetAsyncByIdAsync(EntityDto entity);

        Task<BookTypeDtoOutput> CreateAsync(BookTypeDtoInput entity);

        Task DeleteAsync(EntityDto entity);

        Task<BookTypeDtoOutput> UpdateAsync(BookTypeDtoInput entity);
    }
}
