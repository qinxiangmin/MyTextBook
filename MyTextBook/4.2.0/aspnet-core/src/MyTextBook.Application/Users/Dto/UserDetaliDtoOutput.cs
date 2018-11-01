using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTextBook.Users.Dto
{
    public class UserDetaliDtoOutput:EntityDto
    {
        public string HeadPortrait { get; set; } //用户头像
        public string WorkNumber { get; set; }//学工号
        public string Sex { get; set; }

        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
