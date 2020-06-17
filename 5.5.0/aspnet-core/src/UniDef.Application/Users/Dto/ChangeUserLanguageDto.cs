using System.ComponentModel.DataAnnotations;

namespace UniDef.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}