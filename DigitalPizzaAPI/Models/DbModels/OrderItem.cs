using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalPizzaAPI.Models.DbModels
{
    public class OrderItem
    {
        [Key]
        public Guid ItemId { get; set; }

        [ForeignKey("Orders")]
        public int OrderId { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [ForeignKey("OrderPizzas")]
        public int PizzaId { get; set; }

        public int DipId { get; set; }

        [ForeignKey("DrinkList")]
        public int DrinkId { get; set; }

        public int OtherFoodId { get; set; }
    }
}
