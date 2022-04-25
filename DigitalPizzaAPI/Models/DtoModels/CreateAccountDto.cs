using System.ComponentModel.DataAnnotations;

namespace DigitalPizzaAPI.Models.DtoModels
{
    public class CreateAccountDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "A first name is required.")]
        [MaxLength(128, ErrorMessage = "First name can not exceed 128 characters.")]
        public string FirstName { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "A last name is required.")]
        [MaxLength(128, ErrorMessage = "Last name can not exceed 128 characters.")]
        public string LastName { get; set; } = null!;

        [Required]
        public PhoneNumberDto PhoneNumber { get; set; } = null!;

        [Required]
        public EmailAddressDto EmailAddress { get; set; } = null!;

        [Required]
        public AddressDto Address { get; set; } = null!;

        [Required]
        public PasswordChangeDto Password { get; set; } = null!;
    }
}
