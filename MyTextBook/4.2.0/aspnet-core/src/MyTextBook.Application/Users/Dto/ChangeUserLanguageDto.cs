using System.ComponentModel.DataAnnotations;

namespace MyTextBook.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}