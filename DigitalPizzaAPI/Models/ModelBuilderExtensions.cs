using DigitalPizzaAPI.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DigitalPizzaAPI.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            DateTime seedTimestamp = DateTime.Now;

            #region User Accounts, Roles & Contact Details
            // Default account password is digitalpizza and the following is the sha512 hash value of the default password
            const string defaultPassword = "4AFD6013F1C4F90FCE7E3D29D91BB1F70D10DACFA75FE856FD3494F7CF823133";

            builder.Entity<EmployeeRole>().HasData(new EmployeeRole { Id = 1, Label = "Manager" });
            builder.Entity<EmployeeRole>().HasData(new EmployeeRole { Id = 2, Label = "Cook" });
            builder.Entity<EmployeeRole>().HasData(new EmployeeRole { Id = 3, Label = "Driver" });

            builder.Entity<Employee>().HasData(new Employee
            {
                AccountId = 1,
                RoleId = 1,
                HireDate = DateTime.Parse("2022/04/14"),
                IsActive = true
            });

            builder.Entity<Person>().HasData(new Person
            {
                AccountId = 1,
                IsCustomer = false,
                FirstName = "Stephen",
                LastName = "Davis",
                EmailAddress = "manager@test.com",
                PhoneNumber = "647-787-4877",
                PwdHash = defaultPassword
            });

            builder.Entity<Address>().HasData(new Address
            {
                Id = Guid.Parse("8c94e2ee-199d-4c43-ad3d-78cac71c1c95"),
                AccountId = 1,
                Label = "Fake Address 1",
                StreetNumber = 3898,
                StreetName = "Burdett Avenue",
                City = "Terrace",
                Province = "British Columbia",
                PostCode = "V8G 1S2",
                Notes = "This is a fake testing address. It is not my real address."
            });

            builder.Entity<Employee>().HasData(new Employee
            {
                AccountId = 2,
                RoleId = 2,
                HireDate = DateTime.Parse("2021/05/15"),
                IsActive = true
            });

            builder.Entity<Person>().HasData(new Person
            {
                AccountId = 2,
                IsCustomer = false,
                FirstName = "Sandra",
                LastName = "Rutkowski",
                EmailAddress = "cook@test.com",
                PhoneNumber = "416-555-7310",
                PwdHash = defaultPassword
            });

            builder.Entity<Address>().HasData(new Address
            {
                Id = Guid.Parse("756cb90a-fa3d-4cc1-a6dd-db57005aa05f"),
                AccountId = 2,
                Label = "Home",
                StreetNumber = 1183,
                StreetName = "Clarence Court",
                UnitNumber = "Suite 200",
                City = "Toronto",
                Province = "Ontario",
                PostCode = "L8A 0C3",
                Notes = ""
            });

            builder.Entity<Employee>().HasData(new Employee
            {
                AccountId = 3,
                RoleId = 3,
                HireDate = DateTime.Parse("2021/11/15"),
                IsActive = true
            });

            builder.Entity<Person>().HasData(new Person
            {
                AccountId = 3,
                IsCustomer = false,
                FirstName = "Roger",
                LastName = "Lee",
                EmailAddress = "driver@test.com",
                PhoneNumber = "647-555-2356",
                PwdHash = defaultPassword
            });

            builder.Entity<Address>().HasData(new Address
            {
                Id = Guid.Parse("f2a350d6-5a29-4984-b4e7-2a9c07cc5521"),
                AccountId = 3,
                Label = "Home",
                StreetNumber = 1346,
                StreetName = "Cross Street North",
                UnitNumber = "",
                City = "Southfield",
                Province = "Ontario",
                PostCode = "H3Z 7B5",
                Notes = ""
            });

            builder.Entity<Customer>().HasData(new Customer
            {
                AccountId = 4,
                RewardsCount = 3
                
            });

            builder.Entity<Person>().HasData(new Person
            {
                AccountId = 4,
                FirstName = "Laura",
                LastName = "Kittinger",
                EmailAddress = "customer@test.com",
                PhoneNumber = "437-555-9721",
                IsCustomer = true,
                PwdHash = defaultPassword
            });

            builder.Entity<Address>().HasData(new Address
            {
                Id = Guid.Parse("a3144809-7c8f-4ed8-bcf7-527f68fc0a95"),
                AccountId = 4,
                Label = "Home",
                StreetNumber = 864,
                StreetName = "Aspen Court",
                UnitNumber = "",
                City = "Toronto",
                Province = "Ontario",
                PostCode = "A3H 1D8",
                Notes = "Beware of guard cat"
            });
            #endregion

            #region Drinks List
            builder.Entity<DrinkList>().HasData(new DrinkList { Id = 1, Name = "Coke" });
            builder.Entity<DrinkList>().HasData(new DrinkList { Id = 2, Name = "Sprite" });
            builder.Entity<DrinkList>().HasData(new DrinkList { Id = 3, Name = "Barq's" });
            builder.Entity<DrinkList>().HasData(new DrinkList { Id = 4, Name = "Fanta" });
            builder.Entity<DrinkList>().HasData(new DrinkList { Id = 5, Name = "Ginger Ale" });
            builder.Entity<DrinkList>().HasData(new DrinkList { Id = 6, Name = "Nestea" });
            builder.Entity<DrinkList>().HasData(new DrinkList { Id = 7, Name = "Power Ade", IsPremium = true });
            builder.Entity<DrinkList>().HasData(new DrinkList { Id = 8, Name = "Peace Tea", IsPremium = true });
            builder.Entity<DrinkList>().HasData(new DrinkList { Id = 9, Name = "Gold Peak Tea", IsPremium = true });
            builder.Entity<DrinkList>().HasData(new DrinkList { Id = 10, Name = "Core Power Milk Shake", IsPremium = true });
            #endregion

            #region Default Pizza List
            builder.Entity<PresetPizza>().HasData(new PresetPizza { PresetId = 1, Name = "Special Deluxe", BasePrice = 19.5 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 1, ToppingId = 6 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 1, ToppingId = 19 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 1, ToppingId = 21 });

            builder.Entity<PresetPizza>().HasData(new PresetPizza { PresetId = 2, Name = "Hawaiian Pizza", BasePrice = 18 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 2, ToppingId = 11 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 2, ToppingId = 23 });

            builder.Entity<PresetPizza>().HasData(new PresetPizza { PresetId = 3, Name = "Vegetarian Pizza", BasePrice = 24 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 3, ToppingId = 14 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 3, ToppingId = 18 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 3, ToppingId = 19 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 3, ToppingId = 21 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 3, ToppingId = 22 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 3, ToppingId = 26 });

            builder.Entity<PresetPizza>().HasData(new PresetPizza { PresetId = 4, Name = "Greek Special", BasePrice = 25.5 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 4, ToppingId = 3 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 4, ToppingId = 12 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 4, ToppingId = 14 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 4, ToppingId = 17 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 4, ToppingId = 18 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 4, ToppingId = 22 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 4, ToppingId = 26 });

            builder.Entity<PresetPizza>().HasData(new PresetPizza{ PresetId = 5, Name = "Meat Lovers", BasePrice = 21 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 5, ToppingId = 6 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 5, ToppingId = 7 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 5, ToppingId = 8 });
            builder.Entity<PresetTopping>().HasData(new PresetTopping { EntryId = Guid.NewGuid(), PresetId = 5, ToppingId = 12 });
            #endregion

            #region Topping List
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 1, CategoryId = 1, Name = "Asiago Cheese", IsPremium = true });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 2, CategoryId = 1, Name = "Cheddar Cheese", IsPremium = true });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 3, CategoryId = 1, Name = "Feta Cheese", IsPremium = true });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 4, CategoryId = 1, Name = "Goat Cheese", IsPremium = true });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 5, CategoryId = 1, Name = "Parmigiano Cheese", IsPremium = true });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 6, CategoryId = 2, Name = "Pepperoni" });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 7, CategoryId = 2, Name = "Bacon", IsPremium = true });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 8, CategoryId = 2, Name = "Spicy Sausage" });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 9, CategoryId = 2, Name = "Grilled Chicken", IsPremium = true });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 10, CategoryId = 2, Name = "Anchovies", IsPremium = true });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 11, CategoryId = 2, Name = "Smoked Ham" });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 12, CategoryId = 2, Name = "Ground Beef" });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 13, CategoryId = 3, Name = "Artichokes", IsPremium = true });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 14, CategoryId = 3, Name = "Black Olives" });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 15, CategoryId = 3, Name = "Broccoli" });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 16, CategoryId = 3, Name = "Bruschetta", IsPremium = true });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 17, CategoryId = 3, Name = "Roasted Garlic" });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 18, CategoryId = 3, Name = "Green Olives" });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 19, CategoryId = 3, Name = "Green Peppers" });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 20, CategoryId = 3, Name = "Hot Peppers" });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 21, CategoryId = 3, Name = "Mushrooms" });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 22, CategoryId = 3, Name = "Onions" });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 23, CategoryId = 3, Name = "Pineapple" });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 24, CategoryId = 3, Name = "Red Peppers", IsPremium = true });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 25, CategoryId = 3, Name = "Spinach", IsPremium = true });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 26, CategoryId = 3, Name = "Tomatoes" });
            builder.Entity<ToppingList>().HasData(new ToppingList { ToppingId = 27, CategoryId = 3, Name = "Zucchini", IsPremium = true });
            #endregion

            #region Topping Category List
            builder.Entity<ToppingCategory>().HasData(new ToppingCategory { CategoryId = 1, Name = "Cheese" });
            builder.Entity<ToppingCategory>().HasData(new ToppingCategory { CategoryId = 2, Name = "Meat" });
            builder.Entity<ToppingCategory>().HasData(new ToppingCategory { CategoryId = 3, Name = "Vegetables" });
            #endregion

            #region Sample Orders
            #region Order #1
            builder.Entity<Order>().HasData(new Order
            {
                OrderId = 1,
                CustomerId = 4,
                AddressId = Guid.Parse("a3144809-7c8f-4ed8-bcf7-527f68fc0a95"),
                Timestamp = DateTime.Parse("2022-03-18"),
                StatusMessage = "Order delivered on 2022-03-18",
                InOven = false,
                IsOnRoute = false,
                IsDelivered = true,
                Total = 29.95
            });

            builder.Entity<OrderItem>().HasData(new OrderItem
            {
                ItemId = Guid.NewGuid(),
                OrderId = 1,
                Quantity = 3,
                DrinkId = 1
            });

            builder.Entity<OrderItem>().HasData(new OrderItem
            {
                ItemId = Guid.NewGuid(),
                OrderId = 1,
                Quantity = 1,
                PizzaId = 1
            });

            builder.Entity<OrderPizza>().HasData(new OrderPizza
            {
                PizzaId = 1,
                OrderId = 1,
                PizzaSize = 1,
                IsWellDone = false,
                IsPreset = true,
                PresetId = 5
            });
            #endregion

            #region Order #2
            builder.Entity<Order>().HasData(new Order
            {
                OrderId = 2,
                CustomerId = 4,
                AddressId = Guid.Parse("a3144809-7c8f-4ed8-bcf7-527f68fc0a95"),
                Timestamp = seedTimestamp,
                StatusMessage = "Order in oven",
                InOven = true,
                IsOnRoute = false,
                IsDelivered = false,
                Total = 208.49
            });

            builder.Entity<OrderItem>().HasData(new OrderItem { ItemId = Guid.NewGuid(), OrderId = 2, Quantity = 6, DrinkId = 3 });

            builder.Entity<OrderItem>().HasData(new OrderItem { ItemId = Guid.NewGuid(), OrderId = 2, Quantity = 3, PizzaId = 2 });
            builder.Entity<OrderPizza>().HasData(new OrderPizza { PizzaId = 2, OrderId = 2, PizzaSize = 2, IsWellDone = false, IsPreset = false });
            builder.Entity<OrderToppings>().HasData(new OrderToppings { EntryId = Guid.NewGuid(), PizzaId = 2, ToppingId = 3 });
            builder.Entity<OrderToppings>().HasData(new OrderToppings { EntryId = Guid.NewGuid(), PizzaId = 2, ToppingId = 8 });
            builder.Entity<OrderToppings>().HasData(new OrderToppings { EntryId = Guid.NewGuid(), PizzaId = 2, ToppingId = 14 });
            builder.Entity<OrderToppings>().HasData(new OrderToppings { EntryId = Guid.NewGuid(), PizzaId = 2, ToppingId = 19 });
            builder.Entity<OrderToppings>().HasData(new OrderToppings { EntryId = Guid.NewGuid(), PizzaId = 2, ToppingId = 21 });
            builder.Entity<OrderToppings>().HasData(new OrderToppings { EntryId = Guid.NewGuid(), PizzaId = 2, ToppingId = 26 });

            builder.Entity<OrderItem>().HasData(new OrderItem { ItemId = Guid.NewGuid(), OrderId = 2, Quantity = 1, PizzaId = 3 });
            builder.Entity<OrderPizza>().HasData(new OrderPizza { PizzaId = 3, OrderId = 2, PizzaSize = 4, IsWellDone = true, IsPreset = false });
            builder.Entity<OrderToppings>().HasData(new OrderToppings { EntryId = Guid.NewGuid(), PizzaId = 3, ToppingId = 6 });
            builder.Entity<OrderToppings>().HasData(new OrderToppings { EntryId = Guid.NewGuid(), PizzaId = 3, ToppingId = 13 });
            builder.Entity<OrderToppings>().HasData(new OrderToppings { EntryId = Guid.NewGuid(), PizzaId = 3, ToppingId = 16 });
            builder.Entity<OrderToppings>().HasData(new OrderToppings { EntryId = Guid.NewGuid(), PizzaId = 3, ToppingId = 17 });
            builder.Entity<OrderToppings>().HasData(new OrderToppings { EntryId = Guid.NewGuid(), PizzaId = 3, ToppingId = 24 });

            builder.Entity<OrderItem>().HasData(new OrderItem { ItemId = Guid.NewGuid(), OrderId = 2, Quantity = 2, PizzaId = 4 });
            builder.Entity<OrderPizza>().HasData(new OrderPizza { PizzaId = 4, OrderId = 2, PizzaSize = 3, IsWellDone = true, IsPreset = true, PresetId = 2 });
            #endregion
            #endregion
        }
    }
}
