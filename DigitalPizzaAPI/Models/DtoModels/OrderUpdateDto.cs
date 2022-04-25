namespace DigitalPizzaAPI.Models.DtoModels
{
    public class OrderUpdateDto
    {
        public int OrderId { get; set; }

        public string? StatusMessage { get; set; }

        public bool InOven { get; set; }

        public bool IsOnRoute { get; set; }

        public bool IsDelivered { get; set; }
    }
}
