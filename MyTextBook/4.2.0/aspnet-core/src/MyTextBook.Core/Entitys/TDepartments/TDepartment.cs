using Abp.Domain.Entities;
using MyTextBook.Entitys.Majors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTextBook.Entitys.Department
{
    [Table("AppTDepartments")]

    public class TDepartment:Entity,ISoftDelete
    {       
        public const int MaxNameLength = 56;
        public const int MaxDescriptionLength = 256;

        [Required]
        [StringLength(MaxNameLength)]
        public string TDepartmentName { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public bool IsDeleted { get ; set; }
        public List<Major> Majors { get; set; }
    }
}
