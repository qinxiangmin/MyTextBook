using MyTextBook.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.Users
{
    public class UserDetaliModelView
    {
      
        public UserDetaliDtoOutput User { get; set; }
        public UserDetaliModelView(UserDetaliDtoOutput _user)
        {
            User = _user;
        }
    }
}
