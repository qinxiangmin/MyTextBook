using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTextBook.Users.Dto
{
    public class EditUserDtoInput:EntityDto
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string WorkNumber { get; set; }
    }
}
