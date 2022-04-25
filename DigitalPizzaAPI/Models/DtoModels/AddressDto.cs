using System.ComponentModel.DataAnnotations;

namespace DigitalPizzaAPI.Models.DtoModels
{
    public class AddressDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "An address label is required.")]
        [MaxLength(16, ErrorMessage = "Address label can not exceed 16 characters.")]
        public string Label { get; set; } = null!;

        [Required(ErrorMessage = "Street number is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Your street address must be greater than zero.")]
        public int StreetNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A street name is required.")]
        public string StreetName { get; set; } = null!;

        public string? UnitNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A city is required.")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "A province is required")]
        public string Province { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "A postal code is required.")]
        [StringLength(7, ErrorMessage = "Please enter your postal code in this format (with space): A1B 2C3")]
        public string PostCode { get; set; } = null!;

        [MaxLength(255, ErrorMessage = "Address notes can not exceed 255 characters.")]
        public string? Notes { get; set; }
    }
}
