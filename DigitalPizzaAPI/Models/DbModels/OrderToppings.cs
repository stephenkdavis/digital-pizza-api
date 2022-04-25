using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalPizzaAPI.Models.DbModels
{
    public class OrderToppings
    {
        [Key]
        public Guid EntryId { get; set; }

        [ForeignKey("OrderPizzas")]
        public int PizzaId { get; set; }

        [ForeignKey("ToppingList")]
        public int ToppingId { get; set; }
    }
}
