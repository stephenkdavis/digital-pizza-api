using System.ComponentModel.DataAnnotations;

namespace DigitalPizzaAPI.Models.DtoModels
{
    public class OrderPizzaDto
    {
        public int PizzaId { get; set; }

        public string PizzaName { get; set; }

        [Range(1, 4, ErrorMessage = "Please select a correct size of pizza.")]
        public int PizzaSize { get; set; }

        public bool IsWellDone { get; set; }

        public bool IsPreset { get; set; }

        public int PresetId { get; set; }

        public int Quantity { get; set; }

        public ToppingDto[] Toppings { get; set; }
    }
}
