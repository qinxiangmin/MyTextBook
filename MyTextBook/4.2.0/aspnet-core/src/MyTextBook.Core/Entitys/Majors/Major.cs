using Abp.Domain.Entities;
using MyTextBook.Authorization.Users;
using MyTextBook.Entitys.Department;
using MyTextBook.Entitys.StudentClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTextBook.Entitys.Majors
{
    [Table("AppMajors")]
    public class Major : Entity, ISoftDelete
    {
        public const int MaxNameLength = 256;

        [Required]
        [StringLength(MaxNameLength)]
        public string MajorName { get; set; }

        [StringLength(MaxNameLength)]
        public string LeaderName { get; set; }
      
        public int TDepartmentId { get; set; }
        public TDepartment TDepartment { get; set; }
     
        public List<StudentClass> StudentClass { get; set; }

        public bool IsDeleted { get ; set; } 
    }
}
