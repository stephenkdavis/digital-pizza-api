using System.ComponentModel.DataAnnotations;

namespace DigitalPizzaAPI.Models.DtoModels
{
    public class PasswordChangeDto
    {
        [Required]
        public PasswordDto New { get; set; } = null!;

        [Required]
        public PasswordDto Confirm { get; set; } = null!;
    }
}
