using System.ComponentModel.DataAnnotations;

namespace DigitalPizzaAPI.Models.DtoModels
{
    public class EmailAddressDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "An email address is required.")]
        [MaxLength(255, ErrorMessage = "Email addresses can not exceed 255 characters.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = null!;
    }
}
