using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyTextBook.Applications.Students.Dto;
using MyTextBook.Entitys.Students;

namespace MyTextBook.Applications.Students
{
    public class StudentsAppService : MyTextBookAppServiceBase, IStudentsAppService
    {
        private readonly IRepository<Student> _studnetRepository;//仓储
        public StudentsAppService(IRepository<Student> studentRepository)
        {
            _studnetRepository = studentRepository;
        }
        public async Task<StudentDtoOutput> CreateAsync(StudentDtoInput entity)
        {
            Student student = new Student()
            {
                StudentName = entity.StudentName,
                StudentNum = entity.StudentNum,
                StudentSex = entity.StudentSex,
                StudentClassId = entity.StudentClassId
            };
            var newStudent = await _studnetRepository.InsertAsync(student);
            return new StudentDtoOutput();
        }

        public async Task DeleteAsync(EntityDto entity)
        {
            var student = await _studnetRepository.GetAsync(entity.Id);
            await _studnetRepository.DeleteAsync(student);
        }

        public async Task<PagedResultDto<StudentDtoOutput>> GetAllAsync(StudentPageInput studentPageInput, StudentSeachInput studentSeachInput, StudentOrderInput studentOrderInput)
        {
            var studentList = await _studnetRepository.GetAll().Include(p => p.StudentClass).ToListAsync();

            if (!string.IsNullOrEmpty(studentSeachInput.SeachBookName))
            {
                studentList = studentList.Where(p => p.StudentName.Contains(studentSeachInput.SeachBookName)).ToList();
            }
            if (studentOrderInput.OrderName == "Desc")
            {
                studentList = studentList.OrderByDescending(p => p.StudentName).ToList();
            }
            else
            {
                studentList = studentList.OrderBy(p => p.StudentName).ToList();
            }
            var studentCount = studentList.Count();
            var taskList = studentList.Skip((studentPageInput.pageIndex - 1) * studentPageInput.pageMax).Take(studentPageInput.pageMax).ToList();
            return new PagedResultDto<StudentDtoOutput>(studentCount, taskList.MapTo<List<StudentDtoOutput>>()
                    );
        }

        public async Task<ListResultDto<StudentDtoOutput>> GetAllAsync(EntityDto entity)
        {
            var student = await _studnetRepository.GetAll().Where(p=>p.StudentClassId == entity.Id).ToListAsync();

            return new ListResultDto<StudentDtoOutput>(
                 ObjectMapper.Map<List<StudentDtoOutput>>(student)
                 );
        }

        public async Task<StudentDtoOutput> GetAsyncByIdAsync(EntityDto entity)
        {
            var student = await _studnetRepository.FirstOrDefaultAsync(entity.Id);

            var studentDtoOutput = Mapper.Map<StudentDtoOutput>(student);
            return studentDtoOutput;
        }

        public async Task<StudentDtoOutput> UpdateAsync(StudentDtoInput entity)
        {
            Student student = new Student()
            {   
                Id = entity.Id,
                StudentName = entity.StudentName,
                StudentNum = entity.StudentNum,
                StudentSex = entity.StudentSex,
                StudentClassId = entity.StudentClassId
            };
            var updateStudnet = await _studnetRepository.UpdateAsync(student);

            var studentDtoOutput = Mapper.Map<StudentDtoOutput>(updateStudnet);
            return studentDtoOutput;
        }
    }
}
