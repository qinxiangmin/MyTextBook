using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTextBook.Entitys.AcademicYears
{
    [Table("AppAcademicYears")]
    public class AcademicYear : Entity, ISoftDelete
    {
        public const int MaxNameLength = 30;
        [Required]
        [StringLength(MaxNameLength)]
        public string AcademicYearTitle { get; set; }
        public bool IsDeleted { get ; set ; }
    }
}
