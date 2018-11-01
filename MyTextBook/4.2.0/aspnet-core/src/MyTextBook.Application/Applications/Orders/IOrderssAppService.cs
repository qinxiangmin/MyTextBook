using Abp.Application.Services.Dto;
using MyTextBook.Applications.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTextBook.Applications.Orders
{
    public interface IOrderssAppService
    {
        Task<ListResultDto<OrderDtoOutput>> GetAllAsync(string state);

        Task<ListResultDto<OrderDtoOutput>> GetAllAsync(EntityDto entityDto);

        Task<OrderDetaliOutput> GetAsyncByIdAsync(EntityDto entity);

        Task<OrderDtoOutput> CreateAsync(OrderDtoInput entity);

        Task DeleteAsync(EntityDto entity);

        Task<OrderDtoOutput> UpdateAsync(OrderDtoInput entity);
    }
}
