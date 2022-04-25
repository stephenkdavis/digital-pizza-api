using System.ComponentModel.DataAnnotations;

namespace DigitalPizzaAPI.Models.DtoModels
{
    public class LogInDto
    {
        [Required]
        public EmailAddressDto User { get; set; } = null!;

        [Required]
        public PasswordDto Security { get; set; } = null!;
    }
}
