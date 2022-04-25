namespace DigitalPizzaAPI.Models.DtoModels
{
    public class PresetPizzaDto
    {
        public int PizzaId { get; set; }

        public string PizzaName { get; set; } = null!;

        public double SmallPrice { get; set; }

        public double MediumPrice { get; set; }

        public double LargePrice { get; set; }

        public double PartyPrice { get; set; }

        public ToppingDto[] Toppings { get; set; } = null!;
    }
}
