using System.ComponentModel.DataAnnotations;

namespace DigitalPizzaAPI.Models.DtoModels
{
    public class PhoneNumberDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "A phone number is required.")]
        [MaxLength(12, ErrorMessage = "Phone number can not exceed 12 characters.")]
        public string Phone { get; set; } = null!;
    }
}
