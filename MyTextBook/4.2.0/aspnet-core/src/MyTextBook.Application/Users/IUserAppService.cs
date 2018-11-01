using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTextBook.Roles.Dto;
using MyTextBook.Users.Dto;

namespace MyTextBook.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task<UserDetaliDtoOutput> GetByIdUsersAsync();

        Task ChangeLanguage(ChangeUserLanguageDto input);

       
        Task<UserDetaliDtoOutput> TeacherUpdate(EditUserDtoInput input);
    }
}
