namespace DigitalPizzaAPI.Models.DtoModels
{
    public class MultipleItemDto
    {
        public int ItemId { get; set; }

        public string? ItemName { get; set; }

        public int Quantity { get; set; }
    }

    public class OrderDto
    {
        public int OrderId { get; set; }

        public DateTime Timestamp { get; set; }

        public double Total { get; set; }

        public Guid AddressId { get; set; }

        public OrderPizzaDto[] Pizzas { get; set; } = null!;

        public MultipleItemDto[] Drinks { get; set; } = null!;
    }
}
