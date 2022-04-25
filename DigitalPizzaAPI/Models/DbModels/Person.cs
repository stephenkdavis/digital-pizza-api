using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DigitalPizzaAPI.Models.DbModels
{
    public class Person
    {
        [Key]
        public int AccountId { get; set; }
        
        [DefaultValue(true)]
        public bool IsCustomer { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string PwdHash { get; set; } = null!;
    }
}
