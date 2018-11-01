using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using MyTextBook.Applications.TDepartments.Dto;
using MyTextBook.Entitys.Department;

namespace MyTextBook.Applications.TDepartments
{
    public class TDepartmentsAppService : MyTextBookAppServiceBase, ITDepartmentsAppService
    {
        private readonly IRepository<TDepartment> _tDepartmentRepository;//仓储
        public TDepartmentsAppService(IRepository<TDepartment> tDepartmentRepository)
        {
            _tDepartmentRepository = tDepartmentRepository;

        }
        public async Task<TDepartmentDtoOutput> CreateAsync(TDepartmentDtoInput entity)
        {
            TDepartment department = new TDepartment() {
                 TDepartmentName = entity.TDepartmentName,
                 Description = entity.Description
            };
            var tDepartment = await _tDepartmentRepository.InsertAsync(department);
            var tDepartmentDtoOutput = Mapper.Map<TDepartmentDtoOutput>(tDepartment);
            return tDepartmentDtoOutput;
        }

        public async Task DeleteAsync(EntityDto entity)
        {
            var tDepartment = await _tDepartmentRepository.GetAsync(entity.Id);
            await _tDepartmentRepository.DeleteAsync(tDepartment);

        }

        public async Task<ListResultDto<TDepartmentDtoOutput>> GetAllAsync()
        {
            var tDepartmentList = await _tDepartmentRepository.GetAllListAsync();
            return new ListResultDto<TDepartmentDtoOutput>(
                ObjectMapper.Map<List<TDepartmentDtoOutput>>(tDepartmentList)
                );
        }

        public async Task<TDepartmentDtoOutput> GetAsyncByIdAsync(EntityDto entity)
        {
            var tDepartment = await _tDepartmentRepository.FirstOrDefaultAsync(entity.Id);

            var tDepartmentDtoOutput = Mapper.Map<TDepartmentDtoOutput>(tDepartment);
            return tDepartmentDtoOutput;
        }

        public async Task<TDepartmentDtoOutput> UpdateAsync(TDepartmentDtoInput entity)
        {
            TDepartment tDepartment = new TDepartment()
            {
                Id = entity.Id,
                Description = entity.Description,
                TDepartmentName = entity.TDepartmentName
            };

            var updateTDepartment = await _tDepartmentRepository.UpdateAsync(tDepartment);
            var tDepartmentDtoInputDtoOutput = Mapper.Map<TDepartmentDtoOutput>(updateTDepartment);
            return tDepartmentDtoInputDtoOutput;
        }
    }
}
