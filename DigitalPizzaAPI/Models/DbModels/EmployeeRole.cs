using System.ComponentModel.DataAnnotations;

namespace DigitalPizzaAPI.Models.DbModels
{
    public class EmployeeRole
    {
        [Key]
        public int Id { get; set; }

        public string Label { get; set; } = null!;
    }
}
