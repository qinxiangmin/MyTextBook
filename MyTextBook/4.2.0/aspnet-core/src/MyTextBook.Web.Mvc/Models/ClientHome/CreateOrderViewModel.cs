using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTextBook.Web.Models.ClientHome
{
    public class CreateOrderViewModel
    {
        public const int MaxNameLength = 80;
        public const int MaxDescriptionLength = 256;

      //  [Required]
       // public string CourseNumber { get; set; }

        [Required]
        public int Quantity { get; set; }

        [StringLength(MaxNameLength)]
        public string Customer { get; set; }
     
        public string AcademicYear { get; set; }

        public string Semester { get; set; }
    
        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public int CourseId { get; set; }

        public int BookId { get; set; }
 
        public int StudentClassId { get; set; }

    }
}
