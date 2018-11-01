using System.Collections.Generic;
using MyTextBook.Roles.Dto;
using MyTextBook.Users.Dto;

namespace MyTextBook.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
