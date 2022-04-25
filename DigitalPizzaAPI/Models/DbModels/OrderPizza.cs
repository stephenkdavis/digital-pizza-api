using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalPizzaAPI.Models.DbModels
{
    public class OrderPizza
    {
        [Key]
        public int PizzaId { get; set; }

        [ForeignKey("Orders")]
        public int OrderId { get; set; }

        public int PizzaSize { get; set; }

        public bool IsWellDone { get; set; }

        public bool IsPreset { get; set; }

        public int PresetId { get; set; }
    }
}
