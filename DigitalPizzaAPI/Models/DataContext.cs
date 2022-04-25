using DigitalPizzaAPI.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DigitalPizzaAPI.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DrinkList> DrinkList { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRole { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OrderPizza> OrderPizzas { get; set; }
        public virtual DbSet<OrderToppings> OrderToppings { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PresetPizza> PresetPizzas { get; set; }
        public virtual DbSet<PresetTopping> PresetToppings { get; set; }
        public virtual DbSet<ToppingList> ToppingList { get; set; }
        public virtual DbSet<ToppingCategory> ToppingCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelBuilderExtensions.Seed(modelBuilder);
        }
    }
}
