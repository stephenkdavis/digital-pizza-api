using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalPizzaAPI.Models.DbModels
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        public int AccountId { get; set; }

        public string Label { get; set; } = null!;

        public int StreetNumber { get; set; }

        public string StreetName { get; set; } = null!;

        public string? UnitNumber { get; set; }

        public string City { get; set; } = null!;

        public string Province { get; set; } = null!;

        public string PostCode { get; set; } = null!;

        public string? Notes { get; set; }
    }
}
