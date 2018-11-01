using Abp.Domain.Entities;
using MyTextBook.Entitys.BookTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTextBook.Entitys.Books
{
    [Table("AppBooks")]
    public class Book : Entity, ISoftDelete
    {
        public const int MaxNameLength = 80;
        public const int MaxDescriptionLength = 256;

        [StringLength(MaxNameLength)]
        public string ISBN { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public string BookTitle { get; set; }

        [StringLength(MaxDescriptionLength)]
        public string BookDescription { get; set; }

        [StringLength(MaxNameLength)]
        public string BookAuthor { get; set; }

        [StringLength(MaxNameLength)]
        public string BookPublisher { get; set; }

        public DateTime PublicationDate { get; set; }

        public decimal UnitPrice { get; set; }

        public string Awards { get; set; }

        public int BookTypeId { get; set; }
        public BookType BookType { get; set; }

        public bool IsDeleted { get ; set ; }
    }
}
