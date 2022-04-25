using System.ComponentModel.DataAnnotations;

namespace DigitalPizzaAPI.Models.DbModels
{
    public class PresetPizza
    {
        [Key]
        public int PresetId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public double BasePrice { get; set; }
    }
}
