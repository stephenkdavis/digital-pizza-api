using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalPizzaAPI.Models.DbModels
{
    public class PresetTopping
    {
        [Key]
        public Guid EntryId { get; set; }

        [ForeignKey("DefaultPizzas")]
        public int PresetId { get; set; }

        [ForeignKey("ToppingList")]
        public int ToppingId { get; set; }
    }
}
