namespace DigitalPizzaAPI.Models.DtoModels
{
    public class CustomerDto : PersonDto
    {
        public int CustomerId { get; set; }

        public int RewardsCount { get; set; }
    }
}
