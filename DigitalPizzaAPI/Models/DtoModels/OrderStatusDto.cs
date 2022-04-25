namespace DigitalPizzaAPI.Models.DtoModels
{
    public class OrderStatusDto
    {
        public bool IsInOven { get; set; }

        public bool IsOnRoute { get; set; }

        public bool IsDelivered { get; set; }

        public string Message { get; set; }
    }
}
