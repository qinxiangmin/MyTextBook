using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MyTextBook.Applications.StudentBookDetailses.Dto;
using MyTextBook.Entitys.StudentBookDetailses;
using Microsoft.EntityFrameworkCore;
using MyTextBook.Entitys.Order;
using Abp.AutoMapper;

namespace MyTextBook.Applications.StudentBookDetailses
{
    public class StudentBookAppService : MyTextBookAppServiceBase, IStudentBookAppService
    {
        private readonly IRepository<StudentBookDetails> _studentBookRepository;//仓储
        private readonly IRepository<Order> _orderRepository;//仓储
        public StudentBookAppService(IRepository<StudentBookDetails> studentBookRepository, IRepository<Order> orderRepository)
        {
            _studentBookRepository = studentBookRepository;
            _orderRepository = orderRepository;
        }
        public async Task<StudentBookDtoOutput> CreateAsync(StudentBookDtoInput entity)
        {
            foreach (var item in entity.StudentId)
            {
                var student = new StudentBookDetails() {
                     CourseId = entity.CourseId,
                     StudentId = item,
                     BookId = entity.BookId,
                     AcademicYear = entity.AcademicYear,
                     Quantity = 1,
                     Semester = entity.Semester,
                     UnitPrice = entity.UnitPrice,                  
                };
                var studentBook = await _studentBookRepository.InsertAsync(student);
            }
            var order = await _orderRepository.FirstOrDefaultAsync(entity.OrderId);
            order.OrderState = "2";
            return new StudentBookDtoOutput();
        }

        public async Task DeleteAsync(EntityDto entity)
        {
            var studentBook = await _studentBookRepository.GetAsync(entity.Id);
            await _studentBookRepository.DeleteAsync(studentBook);
        }

        public async Task<ListResultDto<StudentBookDtoOutput>> GetAllAsync()
        {
             var studentBook = await _studentBookRepository.GetAll()
                .Include(p=>p.Student.StudentClass).Include(p => p.Course.CourseType)
                .Include(p => p.Book).ToListAsync();
            return new ListResultDto<StudentBookDtoOutput>(
                  ObjectMapper.Map<List<StudentBookDtoOutput>>(studentBook)
                  );
        }

        public async Task<PagedResultDto<StudentBookDtoOutput>> GetAllAsync(StudentBookPageInput bookPageInput, StudentBookSeachInput bookSeachInput, StudentBookOrderInput bookOrderInput)
        {
            var studentBook = await _studentBookRepository.GetAll()
                .Include(p => p.Student.StudentClass).Include(p => p.Course.CourseType)
                .Include(p => p.Book).ToListAsync();

            if (!string.IsNullOrEmpty(bookSeachInput.AcademicYear))
            {
                studentBook = studentBook.Where(p => p.AcademicYear == bookSeachInput.AcademicYear).ToList();
            }
            if (!string.IsNullOrEmpty(bookSeachInput.Semester))
            {
                studentBook = studentBook.Where(p => p.Semester == bookSeachInput.Semester).ToList();
            }
            if (!string.IsNullOrEmpty(bookSeachInput.StudentClassId))
            {
                studentBook = studentBook.Where(p => p.Student.StudentClassId == Convert.ToInt32(bookSeachInput.StudentClassId)).ToList();
            }
            if (!string.IsNullOrEmpty(bookSeachInput.StudentNum))
            {
                studentBook = studentBook.Where(p => p.Student.StudentNum == bookSeachInput.StudentNum).ToList();
            }
            studentBook = studentBook.OrderBy(p=>p.Student.StudentNum).ToList();//按照学号升序

            var studentBookCount = studentBook.Count();
            var taskList = studentBook.Skip((bookPageInput.pageIndex - 1) * bookPageInput.pageMax).Take(bookPageInput.pageMax).ToList();
            return new PagedResultDto<StudentBookDtoOutput>(studentBookCount, taskList.MapTo<List<StudentBookDtoOutput>>()
                    );
        }

        public Task<StudentBookDtoOutput> GetAsyncByIdAsync(EntityDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<StudentBookDtoOutput> UpdateAsync(StudentBookDtoInput entity)
        {
            throw new NotImplementedException();
        }
    }
}
