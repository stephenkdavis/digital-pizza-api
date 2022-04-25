namespace DigitalPizzaAPI.Models.DtoModels
{
    public class DrinkDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsPremium { get; set; }

        public int Quantity { get; set; }
    }
}
