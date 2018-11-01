using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyTextBook.Applications.Orders.Dto;
using MyTextBook.Applications.Students.Dto;
using MyTextBook.Entitys.Order;

namespace MyTextBook.Applications.Orders
{
    public class OrderssAppService : MyTextBookAppServiceBase, IOrderssAppService
    {
        private readonly IRepository<Order> _orderRepository;//仓储
        public OrderssAppService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderDtoOutput> CreateAsync(OrderDtoInput entity)
        {
            Order order = new Order()
            {
                CourseNumber = "XXXX",
                AcademicYear = entity.AcademicYear,
                BookId = entity.BookId,
                Customer = entity.Customer,
                Description = entity.Description,
                OrderDate = DateTime.Now,
                StudentClassId = entity.StudentClassId,
                Quantity = entity.Quantity,
                Confirmation = false,
                Semester = entity.Semester,
                UserId = Convert.ToInt32(AbpSession.UserId),
                OrderState = "1",
                CourseId = entity.CourseId

            };
            var newOrder = await _orderRepository.InsertAsync(order);

            var orderDtoOutput = Mapper.Map<OrderDtoOutput>(newOrder);
            return orderDtoOutput;
        }

        public Task DeleteAsync(EntityDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ListResultDto<OrderDtoOutput>> GetAllAsync(string state)
        {
            var order = await _orderRepository.GetAll().Include(p => p.Book)
                .Include(p => p.Course).Include(p=>p.StudentClass).Where(p=>p.OrderState == state).ToListAsync();

            return new ListResultDto<OrderDtoOutput>(
                 ObjectMapper.Map<List<OrderDtoOutput>>(order)
                 );
        }

        public async Task<ListResultDto<OrderDtoOutput>> GetAllAsync(EntityDto entity)
        {
            var order = await _orderRepository.GetAll().Include(p => p.Book)
                .Include(p => p.Course).Include(p => p.StudentClass).Where(p=>p.UserId ==entity.Id).ToListAsync();

            return new ListResultDto<OrderDtoOutput>(
                 ObjectMapper.Map<List<OrderDtoOutput>>(order)
                 );
        }

        public async Task<OrderDetaliOutput> GetAsyncByIdAsync(EntityDto entity)
        {
            var order = await _orderRepository.GetAll()
                .Include(p=>p.Book).Include(p=>p.Course).Include(p=>p.StudentClass)
                .FirstOrDefaultAsync(p=>p.Id == entity.Id);

            var orderDtoOutput = Mapper.Map<OrderDetaliOutput>(order);
            return orderDtoOutput;
        }

        public Task<OrderDtoOutput> UpdateAsync(OrderDtoInput entity)
        {
            throw new NotImplementedException();
        }
    }
}
