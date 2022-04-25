using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalPizzaAPI.Models.DbModels
{
    public class ToppingList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ToppingId { get; set; }

        [ForeignKey("ToppingCategory")]
        [Required]
        [Range(1,3)]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [DefaultValue(false)]
        public bool IsPremium { get; set; }
    }
}
