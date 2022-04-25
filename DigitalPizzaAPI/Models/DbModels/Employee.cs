using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalPizzaAPI.Models.DbModels
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountId { get; set; }

        [ForeignKey("EmployeeRole")]
        public int RoleId { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? FireDate { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
