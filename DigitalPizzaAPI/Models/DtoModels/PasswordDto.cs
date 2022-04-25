using System.ComponentModel.DataAnnotations;

namespace DigitalPizzaAPI.Models.DtoModels
{
    public class PasswordDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "A password is required.")]
        [MinLength(8, ErrorMessage = "Passwords must be at least 8 characters long.")]
        [MaxLength(128, ErrorMessage = "Passwords can not exceed 128 characters long.")]
        public string Password { get; set; }
    }
}
