using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DigitalPizzaAPI.Models.DtoModels
{
    public class ToppingDto
    {
        public int ToppingId { get; set; }

        [Range(1, 3)]
        public int CategoryId { get; set; }

        [Required]
        public string ToppingName { get; set; } = null!;

        [DefaultValue(false)]
        public bool IsPremium { get; set; }
    }
}
