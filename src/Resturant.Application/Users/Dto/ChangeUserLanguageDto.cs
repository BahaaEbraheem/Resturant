using System.ComponentModel.DataAnnotations;

namespace Resturant.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}