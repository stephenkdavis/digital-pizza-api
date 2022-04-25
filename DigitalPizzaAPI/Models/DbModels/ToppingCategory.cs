using System.ComponentModel.DataAnnotations;

namespace DigitalPizzaAPI.Models.DbModels
{
    public class ToppingCategory
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; } = null!;
    }
}
