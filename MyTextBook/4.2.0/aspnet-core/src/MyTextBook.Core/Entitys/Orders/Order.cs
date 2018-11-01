using Abp.Domain.Entities;
using MyTextBook.Authorization.Users;
using MyTextBook.Entitys.Books;
using MyTextBook.Entitys.Courses;
using MyTextBook.Entitys.StudentClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTextBook.Entitys.Order
{
    [Table("AppOrders")]
    public class Order : Entity, ISoftDelete
    {
        public const int MaxNameLength = 25;
        public const int MaxDescriptionLength = 256;       

        [Required]
        public string CourseNumber { get; set; }

        [Required]
        public int Quantity { get; set; }

        [StringLength(MaxNameLength)]
        public string Customer { get; set; }

        [Required]
        public bool Confirmation { get; set; }


        public DateTime OrderDate { get; set; }

        public string AcademicYear { get; set; }

        public string Semester { get; set; }

        public string OrderState { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        public int BookId { get; set; }
        public Book Book{ get; set; }

        public int StudentClassId { get; set; }
        public StudentClass StudentClass { get; set; }

        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public bool IsDeleted { get ; set ; }
    }
}
