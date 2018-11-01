using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTextBook.Applications.Books.Dto
{
    public class BookDtoInput:EntityDto
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
    }
}
