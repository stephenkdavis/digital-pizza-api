using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalPizzaAPI.Models.DbModels
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Customers")]
        public int CustomerId { get; set; }

        [ForeignKey("Addresses")]
        public Guid AddressId { get; set; }

        public DateTime Timestamp { get; set; }

        public double Total { get; set; }

        public string? StatusMessage { get; set; }

        [DefaultValue(false)]
        public bool InOven { get; set; }

        [DefaultValue(false)]
        public bool IsOnRoute { get; set; }

        [DefaultValue(false)]
        public bool IsDelivered { get; set; }
    }
}
