using Abp.Domain.Entities;
using MyTextBook.Entitys.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTextBook.Entitys.BookTypes
{
    [Table("AppBookTypes")]
    public class BookType : Entity, ISoftDelete
    {
        public const int MaxNameLength = 20;
        public const int MaxDescriptionLength = 256;

        [Required]
        [StringLength(MaxNameLength)]
        public string BookTypeName { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string BookTypeDescription { get; set; }

        public List<Book> Book { get; set; }

        public bool IsDeleted { get ; set; }
    }
}
